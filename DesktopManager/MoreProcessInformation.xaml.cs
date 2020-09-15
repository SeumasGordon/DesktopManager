using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace DesktopManager
{
    public partial class MoreProcessInformation : Window
    {
        public MoreProcessInformation(Process p)
        {
            InitializeComponent();
            ProcessItem processItem = new ProcessItem(p);
            ProcessName.Text = processItem.ProcessName;
            ProcessID.Text = processItem.Id.ToString();
            RunTime.Text = processItem.UncheckedTime;
            Memory.Text = processItem.Memory;
            User.Text = processItem.UncheckedUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
