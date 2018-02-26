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

        public double HastePercentage { get; set; }

        public int CritRating { get; set; }

        public double CritPercentage { get; set; }

        public int MasteryRating { get; set; }

        public double MasteryPercentage { get; set; }

        public int VersatilityRating { get; set; }

        public double VersatilityPercentage { get; set; }

        public int Stamina { get; set; }

        public int LeechRating { get; set; }

        public double LeechPercentage { get; set; }

        /// <summary>
        /// Spell power or attack power.
        /// </summary>
        public int SecondaryStat { get; set; }
    }
}