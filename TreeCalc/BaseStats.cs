using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class BaseStats {
        public BaseStats(BasePlayerLevelStatics GivenLevelStatics) {
            LevelStatics = GivenLevelStatics;
        }

        //TODO If any of these properties are watched by events, we need to raise the changed property when using Set{}, otherwise anything watching won't see the changes

        private int _HasteRating = 0;
        private decimal _HastePercentage = 0m;

        private int _CritRating = 0;
        private decimal _CritPercentage = 0m;

        private int _MasteryRating = 0;
        private decimal _MasteryPercentage = 0m;

        private int _VersatilityRating = 0;
        private decimal _VersatilityPercentage = 0m;

        private int _LeechRating = 0;
        private decimal _LeechPercentage = 0m;

        /// <summary>
        /// Intellect, strength, or agility.
        /// </summary>
        public int MainStat { get; set; }

        /// <summary>
        /// Spell power or attack power.
        /// </summary>
        public int SecondaryStat { get; set; }

        public int Stamina { get; set; }

        public int HasteRating {
            get {
                return _HasteRating;
            }
            set {
                _HasteRating = value;
                _HastePercentage = (_HasteRating / LevelStatics.HasteRatingConversion / 100) + LevelStatics.BaseHastePercentage;
            }
        }

        public decimal HastePercentage {
            get {
                return _HastePercentage;
            }
            set {
                _HastePercentage = value;
                _HasteRating = Convert.ToInt32((_HastePercentage - LevelStatics.BaseHastePercentage) * LevelStatics.HasteRatingConversion * 100);
            }
        }

        public int CritRating {
            get {
                return _CritRating;
            }
            set {
                _CritRating = value;
                _CritPercentage = (_CritRating / LevelStatics.CritRatingConversion / 100) + LevelStatics.BaseCritPercentage;
            }
        }

        public decimal CritPercentage {
            get {
                return _CritPercentage;
            }
            set {
                _CritPercentage = value;
                _CritRating = Convert.ToInt32((_CritPercentage - LevelStatics.BaseCritPercentage) * LevelStatics.CritRatingConversion * 100);
            }
        }

        public int MasteryRating {
            get {
                return _MasteryRating;
            }
            set {
                _MasteryRating = value;
                _MasteryPercentage = (_MasteryRating / LevelStatics.MasteryRatingConversion / 100) + LevelStatics.BaseMasteryPercentage;
            }

        }

        public decimal MasteryPercentage {
            get {
                return _MasteryPercentage;
            }
            set {
                _MasteryPercentage = value;
                _MasteryRating = Convert.ToInt32((_MasteryPercentage - LevelStatics.BaseMasteryPercentage) * LevelStatics.MasteryRatingConversion * 100);
            }
        }

        public int VersatilityRating {
            get {
                return _VersatilityRating;
            }
            set {
                _VersatilityRating = value;
                _VersatilityPercentage = (_VersatilityRating / LevelStatics.VersatilityRatingConversion / 100) + LevelStatics.BaseVersatilityPercentage;
            }
        }

        public decimal VersatilityPercentage {
            get {
                return _VersatilityPercentage;
            }
            set {
                _VersatilityPercentage = value;
                _VersatilityRating = Convert.ToInt32((_VersatilityPercentage - LevelStatics.BaseVersatilityPercentage) * LevelStatics.VersatilityRatingConversion * 100);
            }
        }

        public int LeechRating {
            get {
                return _LeechRating;
            }
            set {
                _LeechRating = value;
                _LeechPercentage = (_LeechRating / LevelStatics.LeechRatingConversion / 100) + LevelStatics.BaseLeechPercentage;
            }
        }

        public decimal LeechPercentage {
            get {
                return _LeechPercentage;
            }
            set {
                _LeechPercentage = value;
                _LeechRating = Convert.ToInt32((_LeechPercentage - LevelStatics.BaseLeechPercentage) * LevelStatics.LeechRatingConversion * 100);
            }
        }


        public BasePlayerLevelStatics LevelStatics { get; private set; }
    }
}