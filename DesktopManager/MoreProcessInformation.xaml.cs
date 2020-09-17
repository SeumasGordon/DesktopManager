using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;

namespace DesktopManager
{
    public partial class MoreProcessInformation : Window
    {
        Process pro;
        ProcessItem processItem;
        public MoreProcessInformation(Process p)
        {
            InitializeComponent();
            pro = p;
            processItem = new ProcessItem(pro);
            ProcessName.Text = processItem.ProcessName;
            ProcessID.Text = processItem.Id.ToString();
            RunTime.Text = processItem.UncheckedTime;
            Memory.Text = processItem.Memory;
            User.Text = processItem.UncheckedUser;
            PriorityCombo.ItemsSource = Enum.GetValues(typeof(ProcessPriorityClass)).Cast<ProcessPriorityClass>();
            PriorityCombo.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//exit
        {
            ProcessPriorityClass priorityClass = (ProcessPriorityClass)PriorityCombo.SelectionBoxItem;
            try
            {
                if (pro.PriorityClass != priorityClass)
                {
                    pro.PriorityClass = priorityClass;
                }
            }
            catch (Exception)
            {
            }

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
