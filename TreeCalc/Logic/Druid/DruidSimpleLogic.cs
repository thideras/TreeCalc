using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TreeCalc.Logic.Druid {
    public class DruidSimpleLogic : BaseSimulation {
        public DruidSimpleLogic(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers, BaseStats GivenStats, BasePlayerLevelStatics GivenLevelStatics) : base(GivenTickDuration, GivenFightDuration, GivenLabel, GivenPlayers, GivenStats, GivenLevelStatics) {
            //TODO We should automatically add a spell when we use it (this might be slow?) or find some other way to automate this
            TotalHealing.Add(new Spells.Druid.Rejuvenation());
            TotalHealing.Add(new Spells.Druid.Germination());
        }

        protected override void CastHealing() {
            //If we still have the GCD locked out, we can't cast anything
            if (IsGCDLockoutEnabled() == true) {
                return;
            }

            //Attempt to cast rejuvenation on a player
            Player RejuvTarget = PlayerList.Where(p => p.PlayerBuffs.All(b => b.ID != 774)).FirstOrDefault();
            if (RejuvTarget != null) {
                Debug.WriteLine(CurrentTime + " Casting Rejuvenation on player " + RejuvTarget.Name);
                AddPlayerBuff(new Spells.Druid.RejuvenationHoT(), RejuvTarget);
                EnableGCDLockout();
                return;
            }

            Player GermTarget = PlayerList.Where(p => p.PlayerBuffs.All(b => b.ID != 155777)).FirstOrDefault();
            if (GermTarget != null) {
                Debug.WriteLine(CurrentTime + " Casting Germination on player " + GermTarget.Name);
                AddPlayerBuff(new Spells.Druid.GerminationHoT(), GermTarget);
                return;
            }
        }
    }
}