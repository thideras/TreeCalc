﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public abstract class BaseSpell {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ID { get; set; }

        public decimal BaseCost { get; set; }

        public decimal CastTime { get; set; }

        public int Range { get; set; }

        public int SplashRange { get; set; }

        public decimal Cooldown { get; set; }

        public List<BaseBuff> AppliedBuff { get; set; } = new List<BaseBuff>();

        //public List<BaseHeal> AppliedHeal { get; set; } = new List<BaseHeal>();
    }
}