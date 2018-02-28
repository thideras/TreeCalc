using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseSpell {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ID { get; set; }

        public decimal BaseCost { get; set; }

        public decimal CastTime { get; set; }

        public int Range { get; set; }

        public int SplashRange { get; set; }

        public decimal Cooldown { get; set; }

        public bool TriggersGCD { get; set; } = true;

        public List<BaseBuff> AppliedBuff { get; set; } = new List<BaseBuff>();


        //Properties below this line are for calculating statistics of a fight
        public decimal TotalHealing { get; set; } = 0m;

        public int Applications { get; set; } = 0;

        public int Ticks { get; set; } = 0;
    }
}