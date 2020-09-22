using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager
{
    class DriveItem
    {
        public DriveInfo drive { get; }
        public string DriveSpace => GetDriveSpaceAuto();
        public string DriveTotalSpace => drive.TotalSize.ToString();
        public string DriveName => drive.Name;
        public string DriveFormat => drive.DriveFormat;

        public DriveItem(DriveInfo di){
            drive = di;
        }

        private string GetDriveSpaceAuto()
        {
            if (drive.AvailableFreeSpace < 1024)// if uses less than 1kb
            {
                return drive.AvailableFreeSpace + " Bytes";//shows in bytes
            }
            else if (drive.AvailableFreeSpace < 1048576)//if less than 1mb
            {
                double KB = drive.AvailableFreeSpace / 1024.0;//shows in kb
                KB = Math.Round(KB, 2);
                return KB + " KB";
            }
            else if (drive.AvailableFreeSpace < 1073741824)// if greater than a MB
            {
                double MB = drive.AvailableFreeSpace / 1048576.0;// shows in MB
                MB = Math.Round(MB, 2);
                return MB + " MB";
            }
            else if (drive.AvailableFreeSpace < 1099511627776)
            {
                double GB = drive.AvailableFreeSpace / 1073741824;
                GB = Math.Round(GB, 2);
                return GB + " GB";
            }
            else
            {
                double TB = drive.AvailableFreeSpace / 1099511627776;
                TB = Math.Round(TB, 2);
                return TB + " TB";
            }
        }
        private string GetDriveTotalSpaceAuto()
        {
            if (drive.TotalSize < 1024)// if uses less than 1kb
            {
                return drive.TotalSize + " Bytes";//shows in bytes
            }
            else if (drive.TotalSize < 1048576)//if less than 1mb
            {
                double KB = drive.TotalSize / 1024.0;//shows in kb
                KB = Math.Round(KB, 2);
                return KB + " KB";
            }
            else if (drive.TotalSize < 1073741824)// if greater than a MB
            {
                double MB = drive.TotalSize / 1048576.0;// shows in MB
                MB = Math.Round(MB, 2);
                return MB + " MB";
            }
            else if (drive.TotalSize < 1099511627776)
            {
                double GB = drive.TotalSize / 1073741824;
                GB = Math.Round(GB, 2);
                return GB + " GB";
            }
            else
            {
                double TB = drive.TotalSize / 1099511627776;
                TB = Math.Round(TB, 2);
                return TB + " TB";
            }
        }
    }
}
