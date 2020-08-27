using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ProcessItem(Process process)
        {
            Process = process;
        }
    }
}
