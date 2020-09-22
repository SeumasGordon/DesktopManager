﻿using System;
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
    /// Interaction logic for DriveWindow.xaml
    /// </summary>
    public partial class DriveWindow : Window
    {
        public DriveWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Home
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//Settings
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Help
        {
            Help help = new Help();
            help.Show();
            this.Close();
        }
    }
}