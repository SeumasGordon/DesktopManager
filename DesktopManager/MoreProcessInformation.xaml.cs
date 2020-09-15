using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace DesktopManager
{
    /// <summary>
    /// Interaction logic for MoreProcessInformation.xaml
    /// </summary>
    public partial class MoreProcessInformation : Window
    {
        
        public MoreProcessInformation(Process p)
        {
            InitializeComponent();
            ProcessName.Text = p.ProcessName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
