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
        Process process;
        public MoreProcessInformation(Process p)
        {
            process = p;
            InitializeComponent();
        }
    }
}
