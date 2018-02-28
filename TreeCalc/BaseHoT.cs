using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseHoT : BaseBuff {

        public decimal SpellPowerCoefficientPerTick { get; set; }

        public decimal BaseTickDuration { get; set; }
        
        public decimal NextTickTime { get; set; }

        /// <summary>
        /// Determines whether the HoT is affected by haste.
        /// </summary>
        public bool AffectedByHaste { get; set; } = true;
    }
}