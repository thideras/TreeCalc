using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BasePlayerLevelStatics {
        public int Level { get; protected set; }

        public int MainStat { get; protected set; }

        public int Stamina { get; protected set; }

        public int BaseMana { get; protected set; }

        public int Mana { get; protected set; }

        public int ManaPerFive { get; protected set; }

        /// <summary>
        /// Total of all permanent healing increases (artifact weapon, etc)
        /// </summary>
        public decimal OverallHealingIncrease { get; set; }


        public decimal BaseHastePercentage { get; protected set; }

        public decimal BaseCritPercentage { get; protected set; }

        public decimal BaseMasteryPercentage { get; protected set; }

        public decimal BaseVersatilityPercentage { get; protected set; }

        public decimal BaseLeechPercentage { get; protected set; }


        //Conversion rates are [Total rating]/[Conversion rate] = [Percentage] and varies per level and spec
        public decimal HasteRatingConversion { get; protected set; }

        public decimal CritRatingConversion { get; protected set; }

        public decimal MasteryRatingConversion { get; protected set; } 

        public decimal VersatilityRatingConversion { get; protected set; }

        public decimal LeechRatingConversion { get; protected set; }
    }
}