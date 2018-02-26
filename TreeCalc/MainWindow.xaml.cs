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
            Ticker ticker = new Ticker(0.1m, 150m, "Test");
            ticker.Start();
        }
    }
}
