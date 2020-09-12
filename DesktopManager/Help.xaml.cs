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
using System.Windows.Shapes;

namespace DesktopManager
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Settings
        {
            Settings s = new Settings();// settings window
            s.Show();
            this.Close();//closes this window
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//View
        {
            PlaceHolderWindow PHW = new PlaceHolderWindow();//Place Holder Window
            PHW.Show();
            this.Close();//closes this window
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Exit
        {
            MainWindow mw = new MainWindow();//main window
            mw.Show();
            this.Close();//closes this window
        }
    }
}
