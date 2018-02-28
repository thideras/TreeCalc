using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public static class CriticalStrikeRandomizer {
        private static Random CritRand = new Random();

        //0-1,000 allows precision down to xx.xx% critical strike chance
        private static readonly int LowerBound = 0;
        private static readonly int UpperBound = 1000;

        /// <summary>
        /// Returns whether a spell was a critical strike or not. Randomness precision is to four signifigant figures.
        /// </summary>
        /// <param name="CritPercentage"></param>
        /// <returns></returns>
        public static bool IsRandom(decimal CritPercentage) {
            return CritRand.Next(LowerBound, UpperBound) < (CritPercentage * 1000);
        }
    }
}