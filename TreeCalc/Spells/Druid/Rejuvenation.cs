using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc.Spells.Druid {
    public class Rejuvenation : BaseHeal {
        public Rejuvenation() {
            //Wowhead link https://www.wowhead.com/spell=774/rejuvenation
            Name = "Rejuvenation";

            ID = 774;

            BaseCost = 0.10m;
            Cooldown = 0m;
            CastTime = 0m;
            Range = 40;
            SplashRange = 0;
            TriggersGCD = true;

            SpellPowerCoefficient = 0m;
            Description = "Heals the target for (240% of Spell power) over 12 sec.";

            //For right now, the logic to determine who should be healed is going to be outside the spell itself
            //In the future, the spell should be given the list of players for splash/chain buffs
            AppliedBuff.Add(new RejuvenationHoT());
        }
    }
}