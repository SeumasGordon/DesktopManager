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
            if (viewer.SelectProcess != null)
            {
                viewer.KillProcess();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//settings
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//help
        {
            Help h = new Help();
            h.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//Information
        {
            var viewer = (Viewer)DataContext;
            if (viewer.SelectProcess != null)
            {
                MoreProcessInformation information = new MoreProcessInformation(viewer.SelectProcess);
                information.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DriveWindow driveWindow = new DriveWindow();
            driveWindow.Show();
            this.Close();
        }
    }
}
