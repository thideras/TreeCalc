using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc {
    public abstract class BaseSimulation {
        public BaseSimulation(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers, BaseStats GivenStats, BasePlayerLevelStatics GivenLevelStatics) {
            CurrentTime = 0m;
            TickDuration = GivenTickDuration;
            FightDuration = GivenFightDuration;
            Label = GivenLabel;
            PlayerStats = GivenStats;
            LevelStatics = GivenLevelStatics;

            PlayerList.AddRange(GivenPlayers);
        }

        /// <summary>
        /// Current time in the simulation, in seconds.
        /// </summary>
        protected decimal CurrentTime { get; set; }

        /// <summary>
        /// Distance between the current and next 'tick' in time.
        /// </summary>
        protected decimal TickDuration { get; set; }

        /// <summary>
        /// Maximum fight duration, in seconds.
        /// </summary>
        protected decimal FightDuration { get; set; }

        /// <summary>
        /// Prevents casting of spells until the specified time.
        /// </summary>
        protected decimal GCDLockoutUntil { get; set; }

        public string Label { get; private set; }

        protected BaseStats PlayerStats { get; set; }

        protected List<TreeCalc.BaseBuff> AllBuffs { get; set; } = new List<BaseBuff>();

        protected List<Player> PlayerList { get; set; } = new List<Player>();

        protected List<BaseSpell> TotalHealing { get; set; } = new List<BaseSpell>();

        protected BasePlayerLevelStatics LevelStatics { get; set; }

        protected int PlayerMana { get; set; } //This should be part of player stats, but it will be here for testing

        protected abstract void CastHealing();

        public void Start() {
            Debug.WriteLine("Starting fight simulation. Label " + Label + ". Duration " + FightDuration + ". Tick " + TickDuration + ".");
            CurrentTime = 0m;

            //Loop through the entire fight with a time width of the given tick duration
            while (CurrentTime < FightDuration) {
                Tick();
                CurrentTime += TickDuration;
            }

            //Calculate the total healing so we can calculate percentages later
            decimal OverallHealingTotal = 0m;
            foreach (BaseSpell CurrentSpell in TotalHealing) {
                OverallHealingTotal += CurrentSpell.TotalHealing;
            }

            int SpellCount = 1;
            foreach (BaseSpell CurrentSpell in TotalHealing) {
                Debug.WriteLine("");
                Debug.WriteLine("Fight duration: " + FightDuration + " seconds");
                Debug.WriteLine("Total players: {0}", PlayerList.Count);
                Debug.WriteLine("");
                Debug.WriteLine("Total healing: {0:N} ({1:N} HPS)", OverallHealingTotal, OverallHealingTotal/FightDuration);
                Debug.WriteLine(SpellCount++ + ". " + CurrentSpell.Name + " {0:N} - {1:P} ({2:N} HPS)", CurrentSpell.TotalHealing, CurrentSpell.TotalHealing / OverallHealingTotal, CurrentSpell.TotalHealing/FightDuration);
                Debug.WriteLine("");
            }

            Debug.WriteLine("Ending fight simulation. Label " + Label + ".");
        }

        private void Tick() {
            //Walkthrough of a tick:
            //Remove buffs which expired
            //Determine if we are casting anything new
            //Count any active healing

            //Note: The healing logic determines whether it should take action during a GCD, because there are some
            //spells that can be cast during this lockout period which can cause healing, such as Ironbark + Xoni's.

            RemoveExpiredBuffs();
            CastHealing();
            CalculateHoTHealing();
        }

        /// <summary>
        /// Removes any expired buffs from the AllBuffs property
        /// </summary>
        private void RemoveExpiredBuffs() {
            //Find a list of all the buffs which expired
            //We could do a .RemoveAll(<predicate>), but I want to print what we expired for debugging purposes

            //If AllBuffs is null, we can't create a list from it
            if (AllBuffs == null) {
                return;
            }

            List<TreeCalc.BaseBuff> BuffsToRemove = AllBuffs.Where(b => b.EndTime <= CurrentTime).ToList();

            foreach (TreeCalc.BaseBuff CurrentBuff in BuffsToRemove) {
                Debug.WriteLine(CurrentTime + " " + CurrentBuff.Name + " removed from player " + CurrentBuff.OnPlayer.Name);
                CurrentBuff.OnPlayer.PlayerBuffs.Remove(CurrentBuff);
                AllBuffs.Remove(CurrentBuff);
            }

        }

        private void CalculateHoTHealing() {
            List<BaseHoT> ToCalculate = AllBuffs.OfType<BaseHoT>().Where(b => b.NextTickTime <= CurrentTime).ToList();

            foreach(BaseHoT CurrentHoT in ToCalculate) {
                //This is extremely simple logic to calculate how much a HoT does
                //It does not calculate in mastery or any other buffs and is simply to test the base logic
                BaseSpell CurrentHoTTotal = TotalHealing.Where(b => b.ID == CurrentHoT.ID).FirstOrDefault();

                //TODO Verify we have the spell added, this will blow up if the spell isn't in the list
                Decimal HealedAmount = CurrentHoT.SpellPowerCoefficientPerTick * PlayerStats.MainStat;
                CurrentHoTTotal.TotalHealing += HealedAmount;
                Debug.WriteLine(CurrentTime + " Spell " + CurrentHoT.Name + " healed player " + CurrentHoT.OnPlayer.Name + " for " + HealedAmount);

                CurrentHoT.NextTickTime = CurrentTime + CurrentHoT.BaseTickDuration;
            }
        }

        /// <summary>
        /// Adds a buff to the overall buff list, and to the player
        /// </summary>
        /// <param name="GivenBuff"></param>
        /// <param name="GivenPlayer"></param>
        protected void AddPlayerBuff(BaseBuff GivenBuff, Player GivenPlayer) {
            GivenBuff.OnPlayer = GivenPlayer;
            GivenBuff.EndTime = CurrentTime + GivenBuff.DefaultDuration;

            GivenPlayer.PlayerBuffs.Add(GivenBuff);
            AllBuffs.Add(GivenBuff);

            if (GivenBuff.GetType() == typeof(BaseHoT)) {
                //TODO Needs to calculate in effects of haste
                ((BaseHoT)GivenBuff).NextTickTime = CurrentTime + ((BaseHoT)GivenBuff).BaseTickDuration;
            }
        }

        /// <summary>
        /// Enables the lockout of the GCD
        /// </summary>
        protected void EnableGCDLockout() {
            //TODO Calculate haste's effects on the GCD
            GCDLockoutUntil = CurrentTime + 1.5m;
        }

        /// <summary>
        /// Checks to see if we are locked out of casting spells because the GCD is active.
        /// </summary>
        /// <returns></returns>
        protected bool IsGCDLockoutEnabled() {
            return GCDLockoutUntil > CurrentTime;
        }
    }
}