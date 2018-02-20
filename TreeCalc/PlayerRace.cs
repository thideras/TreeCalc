using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeCalc {
    public class PlayerRace {
        public PlayerRace(PlayerRaceList GivenRaceType) {
            switch(GivenRaceType) {
                case PlayerRaceList.BloodElf:
                    ID = 10;
                    Name = "Blood Elf";
                    break;
                case PlayerRaceList.Draenei:
                    ID = 11;
                    Name = "Draenei";
                    break;
                case PlayerRaceList.Dwarf:
                    ID = 3;
                    Name = "Dwarf";
                    break;
                case PlayerRaceList.Gnome:
                    ID = 7;
                    Name = "Gnome";
                    break;
                case PlayerRaceList.Goblin:
                    ID = 9;
                    Name = "Goblin";
                    break;
                case PlayerRaceList.HighmountainTauren:
                    ID = 28;
                    Name = "Highmountain Tauren";
                    break;
                case PlayerRaceList.Human:
                    ID = 1;
                    Name = "Human";
                    break;
                case PlayerRaceList.NightElf:
                    ID = 4;
                    Name = "Night Elf";
                    break;
                case PlayerRaceList.Orc:
                    ID = 2;
                    Name = "Orc";
                    break;
                case PlayerRaceList.Pandaren:
                    ID = 25;
                    Name = "Pandaren";
                    break;
                case PlayerRaceList.Tauren:
                    ID = 6;
                    Name = "Tauren";
                    break;
                case PlayerRaceList.Troll:
                    ID = 8;
                    Name = "Troll";
                    break;
                case PlayerRaceList.Undead:
                    ID = 5;
                    Name = "Undead";
                    break;
                case PlayerRaceList.Worgen:
                    ID = 22;
                    Name = "Worgen";
                    break;
                default:
                    throw new ArgumentException("The given race '" + GivenRaceType.ToString() + "' is not implemented in PlayerRace.");
            }
        }

        public int ID { get; private set; }

        public string Name { get; private set; }
    }
}