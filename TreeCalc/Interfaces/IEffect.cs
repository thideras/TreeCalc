using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Enums;

namespace TreeCalc.Interfaces
{
    public interface IEffect : IBase
    {
        EffectTypes EffectType { get; }
    }
}