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
            Help h = new Help();//help window
            h.Show();
            this.Close();//closes this window
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Exit
        {
            MainWindow mw = new MainWindow();//creates new main window
            mw.Show();//shows main window
            this.Close();//closes this window
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Save
        {
            switch (MemoryViewSizeCombobox.SelectedIndex)
            {
                case 0://Auto
                    SettingsOptions.setMemoryView(0);
                    break;
                case 1://MB
                    SettingsOptions.setMemoryView(1);
                    break;
                case 2://KB
                    SettingsOptions.setMemoryView(2);
                    break;
                case 3://Byte
                    SettingsOptions.setMemoryView(3);
                    break;
                default://NA
                    SettingsOptions.setMemoryView(0);
                    break;
            }
            switch (RefreshViewTimeCombobox.SelectedIndex)
            {
                case 0://.5
                    SettingsOptions.setRefreshView(0);
                    break;
                case 1://1
                    SettingsOptions.setRefreshView(1);
                    break;
                case 2://2
                    SettingsOptions.setRefreshView(2);
                    break;
                case 3://5
                    SettingsOptions.setRefreshView(3);
                    break;
                case 4://10
                    SettingsOptions.setRefreshView(4);
                    break;
                default://NA
                    SettingsOptions.setRefreshView(3);
                    break;
            }

            if (ShowUserCheck.IsChecked == true)
                SettingsOptions.setShowUser(true);
            else
                SettingsOptions.setShowUser(false);
            //Do checks if there was a change
            //if changed change values, and change IsSelected on combobox.
            MainWindow mw = new MainWindow();// main window
            mw.Show();
            this.Close();//closes this window
        }
    }
}
