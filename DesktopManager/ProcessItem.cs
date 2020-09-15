using System;
using System.Diagnostics;
using System.Management;

namespace DesktopManager{
    class ProcessItem{
        public Process Process { get; }//Process
        public int Id => Process.Id;// porcess name
        public string ProcessName => Process.ProcessName;//name of the process
        public string Time => GetRunningTime(Process);//how long a process has ben running
        public string Memory => MemoryConvert(Process);//memory the process uses
        public string User => GetProcessOwner(Id);//user that ran the process

        public ProcessItem(Process process){
            Process = process;
        }

        public static string GetRunningTime(Process p){// Gets the amount of time a process has ran.
            string returns = "Run As Aministrator";//DD:HH;MM;SS.ff
            AdminCheck AC = new AdminCheck();
            if (AC.IsAdmin) { 
                if (p.Id != 0)
                    returns = DateTime.Now.Subtract(p.StartTime).ToString(@"dd\.hh\:mm\:ss\.ff");//Time now - StartTime. ToString With format
                else
                    returns = "00:00:00:00.00";
            }
            return returns;//returns the string.
        }
        public string MemoryConvert(Process p){//Converts memory to a correct size.
            if (SettingsOptions.boolMemoryViewAuto)
            {
                if (p.PrivateMemorySize64 < 1024)// if uses less than 1kb
                {
                    return p.PrivateMemorySize64 + " Bytes";//shows in bytes
                }
                else if (p.PrivateMemorySize64 < 1048576)//if less than 1mb
                {
                    double KB = p.PrivateMemorySize64 / 1024.0;//shows in kb
                    KB = Math.Round(KB, 2);
                    return KB + " KB";
                }
                else// if greater than a MB
                {
                    double MB = p.PrivateMemorySize64 / 1048576.0;// shows in MB
                    MB = Math.Round(MB, 2);
                    return MB + " MB";
                }
            }
            else if (SettingsOptions.boolMemoryViewByte)//If show in Byte
            {
                return p.PrivateMemorySize64 + " Bytes";//Shows byte
            }
            else if (SettingsOptions.boolMemoryViewKilo)//If show in Kb
            {
                double KB = p.PrivateMemorySize64 / 1024.0;//Show in Kb
                KB = Math.Round(KB, 2);
                return KB + " KB";
            }
            else//else show in MB
            {
                double MB = p.PrivateMemorySize64 / 1048576.0;// Show in Mb
                MB = Math.Round(MB, 2);
                return MB + " MB";
            }
        }

        public string GetProcessOwner(int processId)//Gets the owner of a process
        {
            if (SettingsOptions.ShowUser)//checks if feature is enabled
            {
                string query = "Select * From Win32_Process Where ProcessID = " + processId;//query for the ManagementObjectSearcher
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);//Searcher with the query
                ManagementObjectCollection processObjects = searcher.Get();//Gets objs in the process

                foreach (ManagementObject obj in processObjects)// goes through the objs
                {
                    string[] argList = new string[] { string.Empty, string.Empty };
                    int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                    if (returnVal == 0)
                    {
                        // return DOMAIN\user
                        return argList[1] + "\\" + argList[0];
                    }
                }
            }
            return "Enable in Settings";
        }
    }
}
