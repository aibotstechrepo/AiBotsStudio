using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace File_Operations
{
    public sealed class Activate_Window : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Window Title")]
        [RequiredArgument]
        public InArgument<string> tit { get; set; }
 
        //[Category("Output")]
        //[DisplayName("Result")]
        //public OutArgument<bool> Result { get; set; }

        //bool res = false;
        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{ 
                string win = context.GetValue(this.tit);
                if (win.Length > 0)
                {
                 
                    SwitchToWinows(win);
                    //System.Windows.MessageBox.Show("hi" + res.ToString());
                    //Result.Set(context, res);
                }
            //    else
            //    {
            //       // Result.Set(context, false);
            //    }
            //}
            //catch
            //{
            //   // Result.Set(context, false);
            //}

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

        private static void SwitchToWinows(string text)
        {
            List<IntPtr> AllWindowsPtrs = GetAllWindows();
            foreach (IntPtr ThisWindowPtr in AllWindowsPtrs)
            {
                //if (GetTitle(ThisWindowPtr).Contains("Google Chrome") == true)
                if (GetTitle(ThisWindowPtr).Contains(text) == true)
                {
                    //MessageBox.Show("Found Window");

                    SwitchToThisWindow(ThisWindowPtr, true);
                    //Activate_Window a = new Activate_Window();
                    //a.res = true;
                    //CodeActivityContext context =  null;


                    //a.Result.Set(context, true);
                    ////System.Windows.MessageBox.Show("hello" + a.res.ToString());
                }
                else
                { 
                }
            }
             
        }
        #endregion
    }
}
