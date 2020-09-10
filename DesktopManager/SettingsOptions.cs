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

        public static bool boolRefreshViewHalf = false;
        public static bool boolRefreshViewOne = false;
        public static bool boolRefreshViewTwo = false;
        public static bool boolRefreshViewFive = true;
        public static bool boolRefreshViewTen = false;
        public static double RefreshTime = 5;

        public static void setRefreshView(int i)
        {
            switch (i)
            {
                case 0:
                    boolRefreshViewHalf = true;
                    boolRefreshViewOne = false;
                    boolRefreshViewTwo = false;
                    boolRefreshViewFive = false;
                    boolRefreshViewTen = false;
                    RefreshTime = 0.5;
                    break;
                case 1:
                    boolRefreshViewHalf = false;
                    boolRefreshViewOne = true;
                    boolRefreshViewTwo = false;
                    boolRefreshViewFive = false;
                    boolRefreshViewTen = false;
                    RefreshTime = 1;
                    break;
                case 2:
                    boolRefreshViewHalf = false;
                    boolRefreshViewOne = false;
                    boolRefreshViewTwo = true;
                    boolRefreshViewFive = false;
                    boolRefreshViewTen = false;
                    RefreshTime = 2;
                    break;
                case 3:
                    boolRefreshViewHalf = false;
                    boolRefreshViewOne = false;
                    boolRefreshViewTwo = false;
                    boolRefreshViewFive = true;
                    boolRefreshViewTen = false;
                    RefreshTime = 5;
                    break;
                case 4:
                    boolRefreshViewHalf = false;
                    boolRefreshViewOne = false;
                    boolRefreshViewTwo = false;
                    boolRefreshViewFive = false;
                    boolRefreshViewTen = true;
                    RefreshTime = 10;
                    break;
                default:
                    boolRefreshViewHalf = false;
                    boolRefreshViewOne = false;
                    boolRefreshViewTwo = false;
                    boolRefreshViewFive = true;
                    boolRefreshViewTen = false;
                    RefreshTime = 5;
                    break;
            }
        }
    }
}
