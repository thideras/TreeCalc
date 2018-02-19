using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace TreeCalc {
    public class PlayerClass {
        //Class colors https://wow.gamepedia.com/Class_colors

        public PlayerClass(PlayerClassList GivenClassType) {
            switch(GivenClassType) {
                case PlayerClassList.DeathKnight:
                    Name = "Death Knight";
                    ID = 6;
                    Color = (Brush)new BrushConverter().ConvertFromString("#C41F3B");
                    break;
                case PlayerClassList.DemonHunter:
                    Name = "Demon Hunter";
                    ID = 12;
                    Color = (Brush)new BrushConverter().ConvertFromString("#A330C9 ");
                    break;
                case PlayerClassList.Druid:
                    Name = "Druid";
                    ID = 11;
                    Color = (Brush)new BrushConverter().ConvertFromString("#FF7D0A");
                    break;
                case PlayerClassList.Hunter:
                    Name = "Hunter";
                    ID = 3;
                    Color = (Brush)new BrushConverter().ConvertFromString("#ABD473");
                    break;
                case PlayerClassList.Mage:
                    Name = "Mage";
                    ID = 8;
                    Color = (Brush)new BrushConverter().ConvertFromString("#69CCF0");
                    break;
                case PlayerClassList.Monk:
                    Name = "Monk";
                    ID = 10;
                    Color = (Brush)new BrushConverter().ConvertFromString("#00FF96");
                    break;
                case PlayerClassList.Paladin:
                    Name = "Paladin";
                    ID = 2;
                    Color = (Brush)new BrushConverter().ConvertFromString("#F58CBA");
                    break;
                case PlayerClassList.Priest:
                    Name = "Priest";
                    ID = 5;
                    Color = (Brush)new BrushConverter().ConvertFromString("#FFFFFF");
                    break;
                case PlayerClassList.Rogue:
                    Name = "Rogue";
                    ID = 4;
                    Color = (Brush)new BrushConverter().ConvertFromString("#FFF569");
                    break;
                case PlayerClassList.Shaman:
                    Name = "Shaman";
                    ID = 7;
                    Color = (Brush)new BrushConverter().ConvertFromString("#0070DE");
                    break;
                case PlayerClassList.Warlock:
                    Name = "Warlock";
                    ID = 9;
                    Color = (Brush)new BrushConverter().ConvertFromString("#9482C9");
                    break;
                case PlayerClassList.Warrior:
                    Name = "Warrior";
                    ID = 1;
                    Color = (Brush)new BrushConverter().ConvertFromString("#C79C6E");
                    break;
                default:
                    throw new ArgumentException("The given class '" + GivenClassType.ToString() + "' is not implemented in PlayerClass.");
            }
        }

        public int ID { get; private set; }

        public string Name { get; private set; }

        public Brush Color { get; private set; }
    }
}