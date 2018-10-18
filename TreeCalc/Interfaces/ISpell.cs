using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Enums;

namespace TreeCalc.Interfaces
{
    public interface ISpell : IBase
    {
        SpellTypes SpellType { get; }
        decimal CastTime { get; }
        List<IEffect> OnCastEffects { get; }
        bool TriggersGcd { get; }
    }
}