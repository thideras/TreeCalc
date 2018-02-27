using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class BaseStats {
        /// <summary>
        /// Intellect, strength, or agility.
        /// </summary>
        public int MainStat { get; set; }

        public int HasteRating { get; set; }

        public decimal HastePercentage { get; set; }

        public int CritRating { get; set; }

        public decimal CritPercentage { get; set; }

        public int MasteryRating { get; set; }

        public decimal MasteryPercentage { get; set; }

        public int VersatilityRating { get; set; }

        public decimal VersatilityPercentage { get; set; }

        public int Stamina { get; set; }

        public int LeechRating { get; set; }

        public decimal LeechPercentage { get; set; }

        /// <summary>
        /// Spell power or attack power.
        /// </summary>
        public int SecondaryStat { get; set; }
    }
}