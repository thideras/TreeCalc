using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Enums;
using TreeCalc.Interfaces;

namespace TreeCalc.Buffs.Druid
{
    public class RejuvenationBuff : IHot
    {
        public RejuvenationBuff(Player player)
        {
            EffectType = EffectTypes.Buff;
            Id = 774;
            Name = "Rejuvenation";
            Player = player;

            SpellPowerCoefficientPerTick = 0.60m;

            BaseTickDuration = 3m;
            BaseDuration = 12m;
        }

        public EffectTypes EffectType { get; private set; }

        public Player Player { get; private set; }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal ExpirationTime { get; set; }

        public decimal NextTickTime { get; set; }

        public decimal SpellPowerCoefficientPerTick { get; private set; }

        public decimal BaseTickDuration { get; private set; }

        public decimal BaseDuration { get; private set; }
    }
}