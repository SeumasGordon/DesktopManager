using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DesktopManager
{
    //API LOCATION
    //https://docs.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-performance_information?redirectedfrom=MSDN
    //http://www.antoniob.com/windows-psapi-getperformanceinfo-csharp-wrapper
    public static class PerformanceInfoClass
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysAvailableMemory()
        {
            PerformanceInformation performanceInfoClass = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInfoClass, Marshal.SizeOf(performanceInfoClass)))
            {
                return Convert.ToInt64(performanceInfoClass.PhysicalAvailable.ToInt64() * performanceInfoClass.PageSize.ToInt64() / 1048576);
            }
            else{ return -1; }
        }

        public static Int64 GetTotalMemory()
        {
            PerformanceInformation performanceInfoClass = new PerformanceInformation();
            if (GetPerformanceInfo(out performanceInfoClass, Marshal.SizeOf(performanceInfoClass)))
            {
                return Convert.ToInt64(performanceInfoClass.PhysicalTotal.ToInt64() * performanceInfoClass.PageSize.ToInt64() / 1048576);
            }
            else{ return -1; }
        }
    }
}
