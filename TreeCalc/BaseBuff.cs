using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseBuff {

        /// <summary>
        /// Display name of the buff
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display description of the buff
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// WowHead ID for tracking purposes
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Time at which the buff expires and should be removed
        /// </summary>
        public decimal EndTime { get; set; }

        /// <summary>
        /// The player which the buff is currently affecting
        /// </summary>
        public Player OnPlayer { get; set; }
    }
}