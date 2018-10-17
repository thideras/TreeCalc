using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Enums;
using TreeCalc.Interfaces;

namespace TreeCalc.Buffs
{
    public class Rejuvenation : IEffect
    {
        public Rejuvenation(Player player)
        {
            EffectType = EffectTypes.Buff;
            Id = 774;
            Name = "Rejuvenation";
            Player = player;
        }

        public EffectTypes EffectType { get; private set; }

        public Player Player { get; private set; }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal ExpirationTime { get; set; }

        public decimal NextTickTime { get; set; }
    }
}