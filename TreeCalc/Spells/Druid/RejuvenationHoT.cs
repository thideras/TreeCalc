using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc.Spells.Druid {
    public class RejuvenationHoT : BaseHoT {
        public RejuvenationHoT() {
            Name = "Rejuvenation";

            ID = 774;

            SpellPowerCoefficientPerTick = 0.60m;
            BaseTickDuration = 3m;
            DefaultDuration = 12m;
        }
    }
}