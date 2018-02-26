using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc.Logic.Druid {
    public class DruidSimpleLogic : BaseSimulation {
        public DruidSimpleLogic(decimal GivenTickDuration, decimal GivenFightDuration, string GivenLabel, List<Player> GivenPlayers) : base(GivenTickDuration, GivenFightDuration, GivenLabel, GivenPlayers) {
            //Do nothing, the base class handles setup
        }

        protected override void CastHealing() {
            //If we still have the GCD locked out, we can't cast anything
            if (GCDLockoutUntil >= CurrentTime) {
                return;
            }

        }
    }
}