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

namespace DesktopManager{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e){//Click on a process
            var list = (ListBox)sender;

            if (list.SelectedItems.Count > 0){
                var viewer = (Viewer)DataContext;
                viewer.SelectProcess = ((ProcessItem)list.SelectedItems[0]).Process;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e){//kill process
            var viewer = (Viewer)DataContext;
            viewer.KillProcess();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//settings
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//view
        {
            PlaceHolderWindow PHW = new PlaceHolderWindow();//Place holder window
            PHW.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//help
        {
            Help h = new Help();
            h.Show();
            this.Close();
        }
    }
}
