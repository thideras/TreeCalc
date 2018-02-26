using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc.Logic.Druid {
    public class DruidSimpleLogic : BaseSimulation {
        public DruidSimpleLogic(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers, BaseStats GivenStats) : base(GivenTickDuration, GivenFightDuration, GivenLabel, GivenPlayers, GivenStats) {
            //Do nothing, the base class handles setup
        }

        protected override void CastHealing() {
            //If we still have the GCD locked out, we can't cast anything
            if (IsGCDLockoutEnabled() == true) {
                return;
            }

            Player RejuvTarget = PlayerList.Where(p => p.PlayerBuffs.All(b => b.ID != 774)).FirstOrDefault();

            if (RejuvTarget != null) {
                Debug.WriteLine(CurrentTime + " Casting Rejuvenation on player " + RejuvTarget.Name);
                AddPlayerBuff(new Spells.Druid.RejuvenationHoT(), RejuvTarget);
                EnableGCDLockout();
            }
        }
    }
}