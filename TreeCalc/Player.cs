using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class Player {
        public Player(PlayerClassList GivenClassType, PlayerRaceList GivenRaceType, string GivenName) {
            Class = new PlayerClass(GivenClassType);
            Race = new PlayerRace(GivenRaceType);
            Name = GivenName;
            //TODO: Determine if we need a player ID. If an ID is not needed, we need to verify names are unique.
        }

        public string Name { get; private set; }

        public int ID { get; private set; }

        public PlayerClass Class { get; private set; }

        public PlayerRace Race { get; private set; }
    }
}