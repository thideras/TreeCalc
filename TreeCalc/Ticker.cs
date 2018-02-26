using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private List<TreeCalc.BaseBuff> AllBuffs { get; set; }

        public void Start() {
            Console.WriteLine("Starting fight simulation. Label " + Label + ". Duration " + FightDuration + ". Tick " + TickDuration + ".");
            CurrentTime = 0m;

            //Loop through the entire fight with a time width of the given tick duration
            while (CurrentTime < FightDuration) {
                Tick();
                CurrentTime += TickDuration;
            }

            Console.WriteLine("Ending fight simulation. Label " + Label + ".");
        }

        private void Tick() {
            throw new System.NotImplementedException();
        }
    }
}