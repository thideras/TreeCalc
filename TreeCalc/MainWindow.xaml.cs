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
            List<Player> PlayerList = PartyCreator(5);

            BasePlayerLevelStatics LevelStatics = new RestoDruid110Statics();

            BaseStats CurrentStats = new BaseStats(LevelStatics);
            CurrentStats.MainStat = 78000;
            CurrentStats.CritRating = 9489;
            CurrentStats.HasteRating = 9098;
            CurrentStats.MasteryRating = 11832;
            CurrentStats.VersatilityRating = 1749;

            Logic.Druid.DruidSimpleLogic ticker = new Logic.Druid.DruidSimpleLogic(0.01m, 600m, "Test", PlayerList, CurrentStats, LevelStatics);
            ticker.Start();
        }

        private List<Player> PartyCreator(int NumberOfPlayers) {
            List<Player> PlayerList = new List<Player>();

            for(int i = 1; i <= NumberOfPlayers; i++) {
                PlayerList.Add(new Player(PlayerClassList.Druid, PlayerRaceList.HighmountainTauren, "Player" + i.ToString()));
            }

            return PlayerList;
        }
    }
}
