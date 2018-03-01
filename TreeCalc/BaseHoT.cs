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
        /// Percentage of the last tick to count towards healing. See "Remainder Tick" in Calculation Notes.
        /// </summary>
        public decimal PercentRemainingTick { get; set; } = 1m;

        /// <summary>
        /// Determines whether the HoT is affected by haste.
        /// </summary>
        public bool AffectedByHaste { get; set; } = true;
    }
}