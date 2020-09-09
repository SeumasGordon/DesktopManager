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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Help
        {
            PlaceHolderWindow PHW = new PlaceHolderWindow();//Place Holder Window
            PHW.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//View
        {
            PlaceHolderWindow PHW = new PlaceHolderWindow();//Place Holder Window
            PHW.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Exit
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Save
        {
            //Do checks if there was a change
            //if changed change values, and change IsSelected on combobox.
            this.Close();
        }
    }
}
