using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc {
    public abstract class BaseSimulation {
        public BaseSimulation(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers, BaseStats GivenStats) {
            CurrentTime = 0m;
            TickDuration = GivenTickDuration;
            FightDuration = GivenFightDuration;
            Label = GivenLabel;
            HealerStats = GivenStats;

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

        protected BaseStats HealerStats { get; set; }

        protected List<TreeCalc.BaseBuff> AllBuffs { get; set; } = new List<BaseBuff>();

        protected List<Player> PlayerList { get; set; } = new List<Player>();

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
            List<BaseBuff> ToCalculate = AllBuffs.Where(b => b.)
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