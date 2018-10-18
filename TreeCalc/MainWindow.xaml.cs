using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

using log4net;
using TreeCalc.Buffs.Druid;
using TreeCalc.HealingLogic.Druid;

namespace TreeCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var instance = new DruidSimpleLogic(1, 30m);
            var playerThid = new Player("thideras");
            var playerGren = new Player("grennish");
            var playerShad = new Player("YOURNAMEHERE");
            var playerWayg = new Player("waygu");
            var playerBrim = new Player("brimgor");

            instance.AddPlayer(playerThid);
            instance.AddPlayer(playerGren);
            instance.AddPlayer(playerShad);
            instance.AddPlayer(playerWayg);
            instance.AddPlayer(playerBrim);

            instance.AddHot(new RejuvenationBuff(playerGren));

            instance.NextAction();
            instance.NextAction();
            instance.NextAction();
            instance.NextAction();
            instance.NextAction();
            instance.NextAction();
        }
    }
}
