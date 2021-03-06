﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Enums;

namespace TreeCalc.Interfaces
{
    public interface IEffect : IBase
    {
        EffectTypes EffectType { get; }
        Player Player { get; }
        decimal ExpirationTime { get; set; }
        decimal NextTickTime { get; set; } //This will be moved to an IHoT interface later
    }
}