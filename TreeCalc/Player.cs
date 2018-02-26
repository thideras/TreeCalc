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

            //DEBUG: Stats are manually set so we don't have to add up gear. In the future, this data will be pulled from the gear and buffs during normal execution
            //Int: 75466
            //Stam: 108157, 6.49m health
            //Mana regen: 48,400 per 5 seconds
            //Crit: 5% + 9472 = 28.68%
            //Haste: 9098 = 24.26%
            //Mastery: 4.80% + 11816 = 22.52%
            //Vers: 1749 = 3.68%

            //Base stats 110 Highmountain Tauren
            //Int: 7327
            //Stam: 6261, 375.7k health
            //Mana: 44,000 per 5 seconds
            //Crit: 5%
            //Mastery: 4.80%
            //Vers: 1%
        }

        public string Name { get; private set; }

        public int ID { get; private set; }

        public PlayerClass Class { get; private set; }

        public PlayerRace Race { get; private set; }

        public BaseStats PlayerStats { get; private set; }

        public PlayerGearSlots GearSlots { get; private set; }

        public BaseStats TotalGearStats { get; private set; }
    }
}