using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeCalc.Buffs.Druid;
using TreeCalc.Enums;
using TreeCalc.Interfaces;

namespace TreeCalc.Spells.Druid
{
    public class Rejuvenation : ISpell
    {
        public Rejuvenation(Player targetPlayer)
        {
            //Wowhead link https://www.wowhead.com/spell=774/rejuvenation
            Id = 774;
            Name = "Rejuvenation";

            TriggersGcd = true;
            SpellType = SpellTypes.Buff;
            CastTime = 0m;

            OnCastEffects.Add(new RejuvenationBuff(targetPlayer));
        }

        public SpellTypes SpellType { get; private set; }

        public decimal CastTime { get; private set; }

        public List<IEffect> OnCastEffects { get; private set; } = new List<IEffect>();

        public int Id { get; private set; }

        public string Name { get; private set; }

        public bool TriggersGcd { get; private set; }
    }
}
