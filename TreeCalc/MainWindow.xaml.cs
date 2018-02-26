using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeCalc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            //If we are in a debug build, add the listener so we can see debug output
#if DEBUG
            TextWriterTraceListener debugWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(debugWriter);
#endif
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            //Test players
            List<Player> PlayerList = new List<Player>();

            Player playerThideras = new Player(PlayerClassList.Druid, PlayerRaceList.HighmountainTauren, "Thideras");
            Player playerShadowruin = new Player(PlayerClassList.Hunter, PlayerRaceList.BloodElf, "Shadowruin");
            Player playerImpezor = new Player(PlayerClassList.Priest, PlayerRaceList.Goblin, "Impezor");
            Player playerBrimgor = new Player(PlayerClassList.Monk, PlayerRaceList.BloodElf, "Brimgor");
            Player playerBub = new Player(PlayerClassList.Warrior, PlayerRaceList.Tauren, "Bubelien");

            PlayerList.Add(playerThideras);
            PlayerList.Add(playerShadowruin);
            PlayerList.Add(playerImpezor);
            PlayerList.Add(playerBrimgor);
            PlayerList.Add(playerBub);


            Ticker ticker = new Ticker(0.1m, 150m, "Test", PlayerList);
            ticker.Start();
        }
    }
}
