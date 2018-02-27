using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class RestoDruid110Statics : BasePlayerLevelStatics {
        RestoDruid110Statics() {
            Level = 110;
            MainStat = 7327;
            Stamina = 6261;
            ManaPerFive = 44000; //44,000
            BaseMana = 220000;   //220,000
            Mana = 1100000;      //1,100,000


            BaseHastePercentage = 0m;
            BaseCritPercentage = 0.05m;
            BaseMasteryPercentage = 0m;

            HasteRatingConversion = 375;
            CritRatingConversion = 400;
            MasteryRatingConversion = 667;
            LeechRatingConversion = 230;
        }
    }
}