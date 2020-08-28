﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager
{
    class ProcessItem
    {
        public Process Process { get; }
        public int Id => Process.Id;
        public string ProcessName => Process.ProcessName;
        public string Time => GetRunningTime(Process);

        public ProcessItem(Process process)
        {
            Process = process;
        }

        public string GetRunningTime(Process p)
        {
            string returns = "00:00:00:00.00";
            try
            {
                returns = DateTime.Now.Subtract(p.StartTime).ToString(@"dd\.hh\:mm\:ss\.ff");
            }
            catch (Exception)
            {
            }
            return returns;
        }
    }
}
