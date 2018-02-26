using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseHoT : BaseBuff {

        public decimal SpellPowerCoefficientPerTick {
            get => default(int);
            set {
            }
        }

        public decimal BaseTickDuration {
            get => default(int);
            set {
            }
        }
    }
}