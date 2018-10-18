using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeCalc.Interfaces
{
    public interface IHot : IEffect
    {
        decimal NextTickTime { get; set; }
        decimal SpellPowerCoefficientPerTick { get; }
        decimal BaseTickDuration { get; }
    }
}
