using System;
using System.Collections.Generic;
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

namespace GroundTerminalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //This is just TEMP!!
        Server theServer = new Server("50001");

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Provides the ability to switch between the Real Time Information System tab and the Database Search tab.
        /// </summary>
        /// <param name="sender">Object which called this method.</param>
        /// <param name="e">Calling event args.</param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Add code to change between tabs here.
        }

        private void StartServerBtn_Click(object sender, RoutedEventArgs e)
        {
            theServer.StartBeingAServer();
        }

        private void StopServerBtn_Click(object sender, RoutedEventArgs e)
        {
            theServer.StopBeingAServer();
        }
    }
}
