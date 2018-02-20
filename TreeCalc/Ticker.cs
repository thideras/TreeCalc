using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class Ticker {
        public Ticker(decimal GivenTickDuration, decimal GivenFightDuration) {
            CurrentTime = 0m;
            TickDuration = GivenTickDuration;
            FightDuration = GivenFightDuration;
        }

        private decimal CurrentTime { get; set; }

        private decimal TickDuration { get; set; }

        public decimal FightDuration { get; set; }

        public void Start() {
            throw new System.NotImplementedException();
        }

        private void Tick() {
            throw new System.NotImplementedException();
        }
    }
}