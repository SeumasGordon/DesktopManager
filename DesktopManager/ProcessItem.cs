using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager{
    class ProcessItem{
        public Process Process { get; }
        public int Id => Process.Id;
        public string ProcessName => Process.ProcessName;
        public string Time => GetRunningTime(Process);
        public string Memory => MemoryConvert(Process);

        public ProcessItem(Process process){
            Process = process;
        }

        public static string GetRunningTime(Process p)
        {
            //string returns = "00:00:00:00.00";//DD:HH;MM;SS.ff
            //try{
            //    returns = DateTime.Now.Subtract(p.StartTime).ToString(@"dd\.hh\:mm\:ss\.ff");//Time now - StartTime. ToString With format
            //}catch (Exception){}
            //return returns;//returns the string.
            return "Not finished";
        }
        public string MemoryConvert(Process p)
        {
            if (p.PrivateMemorySize64 < 1024){
                return p.PrivateMemorySize64 + " Bytes";
            }
            else if (p.PrivateMemorySize64 < 1048576){
                long KB = p.PrivateMemorySize64 / 1024;
                return KB + " KB";
            }
            else{
                long MB = p.PrivateMemorySize64 / 1048576;
                return MB + " MB";
            }
        }
    }
}
