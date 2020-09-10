using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopManager
{
    public static class SettingsOptions
    {
        public static bool boolMemoryViewAuto = true;
        public static bool boolMemoryViewMega = false;
        public static bool boolMemoryViewKilo = false;
        public static bool boolMemoryViewByte = false;

        public static void setMemoryView(int i)
        {
            switch (i)
            {
                case 0:
                    boolMemoryViewAuto = true;
                    boolMemoryViewMega = false;
                    boolMemoryViewKilo = false;
                    boolMemoryViewByte = false;
                    break;
                case 1:
                    boolMemoryViewAuto = false;
                    boolMemoryViewMega = true;
                    boolMemoryViewKilo = false;
                    boolMemoryViewByte = false;
                    break;
                case 2:
                    boolMemoryViewAuto = false;
                    boolMemoryViewMega = false;
                    boolMemoryViewKilo = true;
                    boolMemoryViewByte = false;
                    break;
                case 3:
                    boolMemoryViewAuto = false;
                    boolMemoryViewMega = false;
                    boolMemoryViewKilo = false;
                    boolMemoryViewByte = true;
                    break;
                default:
                    break;
            }
        }

        
        public static double RefreshTime = 5;

        public static void setRefreshView(int i)
        {
            switch (i)
            {
                case 0:
                    RefreshTime = 0.5;
                    break;
                case 1:
                    RefreshTime = 1;
                    break;
                case 2:
                    RefreshTime = 2;
                    break;
                case 3:
                    RefreshTime = 5;
                    break;
                case 4:
                    RefreshTime = 10;
                    break;
                default:
                    RefreshTime = 5;
                    break;
            }
        }
    }
}
