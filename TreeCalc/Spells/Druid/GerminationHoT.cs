using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc.Spells.Druid {
    public class GerminationHoT : BaseHoT {
        public GerminationHoT() {
            Name = "Rejuvenation (Germination)";

            ID = 155777;

            SpellPowerCoefficientPerTick = 0.60m;
            BaseTickDuration = 3m;
            DefaultDuration = 12m;
        }
    }
}