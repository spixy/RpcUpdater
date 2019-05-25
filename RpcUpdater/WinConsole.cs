using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace RpcUpdater
{
    public static class WinConsole
    {
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        /// <summary>
        /// Show Windows console
        /// </summary>
        public static void Show()
        {
            AllocConsole();

            var stdHandle = GetStdHandle(-11);
            var safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
            var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            var standardOutput = new StreamWriter(fileStream, Encoding.ASCII)
            {
                AutoFlush = true
            };

            Console.SetOut(standardOutput);
        }
    }
}
