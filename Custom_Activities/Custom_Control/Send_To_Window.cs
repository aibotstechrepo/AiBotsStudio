using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Custom_Control
{

    public sealed class Send_To_Window : CodeActivity
    {
        public InArgument<string> Send { get; set; }
        public InArgument<string> Window { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Send);
            string win = context.GetValue(this.Window);
            if (text.Length > 0)
            {
                SwitchToChromeWinows(win);
                Thread.Sleep(3000);
                SendKeys.SendWait(text);
            }
            //SendKeys.SendWait(text);
        }

        #region functionality

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(Win32Callback enumProc, IntPtr lParam);

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            List<IntPtr> pointers = GCHandle.FromIntPtr(pointer).Target as List<IntPtr>;
            pointers.Add(handle);
            return true;
        }

        private static List<IntPtr> GetAllWindows()
        {
            Win32Callback enumCallback = new Win32Callback(EnumWindow);
            List<IntPtr> AllWindowPtrs = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(AllWindowPtrs);
            try
            {
                EnumWindows(enumCallback, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return AllWindowPtrs;
        }

        [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr windowHandle, StringBuilder stringBuilder, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true)]
        internal static extern int GetWindowTextLength(IntPtr hwnd);
        private static string GetTitle(IntPtr handle)
        {
            int length = GetWindowTextLength(handle);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(handle, sb, sb.Capacity);
            return sb.ToString();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        private static void SwitchToChromeWinows(string text)
        {
            List<IntPtr> AllWindowsPtrs = GetAllWindows();
            foreach (IntPtr ThisWindowPtr in AllWindowsPtrs)
            {
                //if (GetTitle(ThisWindowPtr).Contains("Google Chrome") == true)
                if (GetTitle(ThisWindowPtr).Contains(text) == true)
                {
                    //MessageBox.Show("Found Window");

                    SwitchToThisWindow(ThisWindowPtr, true);
                }
            }
        }
        #endregion
    }
}
