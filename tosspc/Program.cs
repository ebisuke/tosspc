using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace tosspc
{
    internal class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();
        public static void Main(string[] args)
        {
            Process tos = Process.Start(args[2]);
            while (!tos.HasExited)
            {

                if (GetActiveWindow() == tos.MainWindowHandle)
                {
                    SendKeys.Send(" ");
                }
                Thread.Sleep(100);
            }
            
        }
    }
}