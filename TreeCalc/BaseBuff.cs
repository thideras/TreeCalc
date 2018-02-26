using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseBuff {

        public string Name { get; set; }

        public string Description { get; set; }

        public int ID { get; set; }

        public decimal EndTime { get; set; }

        public int PlayerID { get; set; }
    }
}