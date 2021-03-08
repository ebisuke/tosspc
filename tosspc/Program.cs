using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace tosspc
{
    internal class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        public static void Main(string[] args)
        {
            string path =
                @"steam://rungameid/1175730";
            if (args.Length > 0)
            {
                path = args[0];
            }
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = path,

            };
            Console.WriteLine("Tos Auto 64bit Launcher by ebisuke");
            Console.WriteLine("この画面は正常に起動後自動で閉じられます");

            Process tos = Process.Start(psi);
            while (!tos.HasExited)
            {
                
                IntPtr hnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, "TreeOfSavior");
                if (hnd != IntPtr.Zero)
                {
                    
                    IntPtr btn = GetDlgItem(hnd, 0x041b);
                    if (btn!=IntPtr.Zero)
                    {
                        PostMessage(btn, 0x0201, 0x0001, IntPtr.Zero);
                        Thread.Sleep(10);
                        PostMessage(btn, 0x0202, 0, IntPtr.Zero);
                    }
                }

                Thread.Sleep(100);
            }
            
        }
    }
}