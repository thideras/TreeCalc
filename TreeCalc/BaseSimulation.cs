using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc {
    public abstract class BaseSimulation {
        public BaseSimulation(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers) {
            CurrentTime = 0m;
            TickDuration = GivenTickDuration;
            FightDuration = GivenFightDuration;
            Label = GivenLabel;

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

        protected List<TreeCalc.BaseBuff> AllBuffs { get; set; } = new List<BaseBuff>();

        protected List<Player> PlayerList { get; set; } = new List<Player>();

        protected abstract void CastHealing();

        public void Start() {
            Debug.WriteLine("Starting fight simulation. Label " + Label + ". Duration " + FightDuration + ". Tick " + TickDuration + ".");
            CurrentTime = 0m;

            //Debug
            //TreeCalc.BaseBuff hello = new BaseBuff();
            //hello.Name = "Rejuvenation";
            //hello.EndTime = 15m;
            //AllBuffs.Add(hello);

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

            RemoveExpiredBuffs();
            CastHealing();
            //Calculate healing
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
                Debug.WriteLine(CurrentBuff.Name + " removed from player " + CurrentBuff.OnPlayer.Name);
                AllBuffs.Remove(CurrentBuff);
                
            }

        }
    }
}