using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc {
    public class Ticker {
        public Ticker(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel) {
            CurrentTime = 0m;
            TickDuration = GivenTickDuration;
            FightDuration = GivenFightDuration;
            Label = GivenLabel;
        }

        private decimal CurrentTime { get; set; }

        private decimal TickDuration { get; set; }

        private decimal FightDuration { get; set; }

        public string Label { get; private set; }

        private List<TreeCalc.BaseBuff> AllBuffs { get; set; } = new List<BaseBuff>();

        public void Start() {
            Debug.WriteLine("Starting fight simulation. Label " + Label + ". Duration " + FightDuration + ". Tick " + TickDuration + ".");
            CurrentTime = 0m;

            //Debug
            TreeCalc.BaseBuff hello = new BaseBuff();
            hello.Name = "Rejuvenation";
            hello.PlayerID = 1;
            hello.EndTime = 15m;
            AllBuffs.Add(hello);

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
            //Cast new healing
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
                Debug.WriteLine(CurrentBuff.Name + " removed from player " + CurrentBuff.PlayerID);
                AllBuffs.Remove(CurrentBuff);
                
            }

        }
    }
}