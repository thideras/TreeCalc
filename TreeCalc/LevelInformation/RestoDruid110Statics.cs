using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class RestoDruid110Statics : BasePlayerLevelStatics {
        private readonly decimal NaturesVigor = 0.15m;
        private readonly decimal Grovewalker = 0.04m;
        private readonly decimal GraceOfTheCenarionCircle = 0.10m;
        private readonly decimal GHanirsBloom = 0.05m;

        public RestoDruid110Statics() {
            Level = 110;
            MainStat = 7327;
            Stamina = 6261;
            ManaPerFive = 44000; //44,000
            BaseMana = 220000;   //220,000
            Mana = 1100000;      //1,100,000

            OverallHealingIncrease = NaturesVigor + Grovewalker + GraceOfTheCenarionCircle + GHanirsBloom;

            BaseHastePercentage = 0m;
            BaseCritPercentage = 0.05m;
            BaseMasteryPercentage = 0.048m;
            BaseVersatilityPercentage = 0m;
            BaseLeechPercentage = 0m;

            HasteRatingConversion = 375;
            CritRatingConversion = 400;
            MasteryRatingConversion = 667;
            VersatilityRatingConversion = 475;
            LeechRatingConversion = 230;
        }
    }
}