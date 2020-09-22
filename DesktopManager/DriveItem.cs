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

        public DriveItem(DriveInfo di){
            drive = di;
        }
    }
}
