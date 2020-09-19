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
            processStartTime.Text = TryGetStartTime();
            Memory.Text = processItem.Memory;
            NonPageMemory.Text = pro.NonpagedSystemMemorySize64.ToString();
            VirtualMemory.Text = pro.VirtualMemorySize64.ToString();
            User.Text = processItem.UncheckedUser;
            PriorityCombo.ItemsSource = Enum.GetValues(typeof(ProcessPriorityClass)).Cast<ProcessPriorityClass>();
            PriorityCombo.SelectedIndex = 0;
            Threads.Text = pro.Threads.Count.ToString();
            HandleNum.Text = pro.HandleCount.ToString();
            HandleMain.Text = tryMainHandle();
            FileName.Text = pro.StartInfo.FileName;
            FileDir.Text = pro.StartInfo.WorkingDirectory;
            SessionID.Text = pro.SessionId.ToString();
        }

        private string tryMainHandle()
        {
            string s = "Run as Administrator";
            try
            {
                s = pro.Handle.ToString();
            }
            catch (Exception)
            {
            }
            return s;
        }

        private string TryGetStartTime()
        {
            string r = "Run as Administrator";
            try
            {
                r = pro.StartTime.ToString();
            }
            catch (Exception)
            {
            }
            return r;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//exit
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Close
        {
            if (!pro.HasExited)//If process has not been exited
            {
                pro.Kill();//kills process
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Save
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
