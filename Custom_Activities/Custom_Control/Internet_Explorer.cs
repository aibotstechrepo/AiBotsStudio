using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Custom_Control
{

    public sealed class Internet_Explorer : CodeActivity
    {
        Data_Transition c = new Data_Transition();
        CustomFunction d = new CustomFunction();
        // Define an activity input argument of type string
        public InArgument<string> Website { get; set; }
        
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string website = context.GetValue(this.Website);

           //Process.Start("IExplore.exe", website);
           Process.Start("IExplore.exe", "http://localhost:3581/Login.aspx");
            //Login
            Thread.Sleep(3000);
            c.Mouse_Left(700, 420);
            Thread.Sleep(1000);
            SendKeys.SendWait("admin");
            c.Mouse_Left(700, 490);
            Thread.Sleep(1000);
            SendKeys.SendWait("admin123");
            c.Mouse_Left(700, 560);
            Thread.Sleep(5000);

            //Navigation
            c.Mouse_Left(78, 490);
            Thread.Sleep(2000);
            c.Mouse_Left(80, 588);
            Thread.Sleep(3000);


            //List data 1 
            c.Mouse_Left(1000, 250);
            Thread.Sleep(1000);
            c.Mouse_Left(1000, 338);
            Thread.Sleep(1000);
             
            c.Mouse_Left(958, 295);
            Thread.Sleep(1000);
            c.Mouse_Left(957, 332);
            Thread.Sleep(1000);

            ////----------------------------------------------
            c.Mouse_Left(1019, 455);
            Thread.Sleep(1000);
            SendKeys.SendWait("INV-3288");

            c.Mouse_Left(1019, 506);
            Thread.Sleep(1000);
            SendKeys.SendWait("2/3/2018");

            c.Mouse_Left(1019, 558);
            Thread.Sleep(1000);
            SendKeys.SendWait("3500");

            c.Mouse_Left(1019, 605);
            Thread.Sleep(1000);
            SendKeys.SendWait("350");

            c.Mouse_Left(1019, 650);
            Thread.Sleep(1000);
            SendKeys.SendWait("3850");

            c.Mouse_Left(687, 705);
            Thread.Sleep(2000);
            c.Mouse_Left(746, 627);
            c.Mouse_Left(746, 627);
            Thread.Sleep(3000);
            ////--------------------------------------------



            //List data 2 
            c.Mouse_Left(1000, 250);
            Thread.Sleep(1000);
            c.Mouse_Left(1000, 338);
            Thread.Sleep(1000);

            c.Mouse_Left(958, 295);
            Thread.Sleep(1000);
            c.Mouse_Left(957, 316);
            Thread.Sleep(1000);

            ////----------------------------------------------
            c.Mouse_Left(1019, 455);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("INV-3367");

            c.Mouse_Left(1019, 506);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("13/03/2018");

            c.Mouse_Left(1019, 558);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("15200");

            c.Mouse_Left(1019, 605);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("1520");

            c.Mouse_Left(1019, 650);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("16720");

            c.Mouse_Left(687, 705);
            Thread.Sleep(2000);
            c.Mouse_Left(746, 627);
            c.Mouse_Left(746, 627);
            Thread.Sleep(3000);
            ////--------------------------------------------


            //List data 3 
            c.Mouse_Left(1000, 250);
            Thread.Sleep(1000);
            c.Mouse_Left(1000, 270);
            Thread.Sleep(1000);

            c.Mouse_Left(958, 295);
            Thread.Sleep(1000);
            c.Mouse_Left(957, 316);
            Thread.Sleep(1000);

            ////----------------------------------------------
            c.Mouse_Left(1019, 455);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("VCI/00876");

            c.Mouse_Left(1019, 506);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("1/3/2018");

            c.Mouse_Left(1019, 558);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("2000");

            c.Mouse_Left(1019, 605);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("200");

            c.Mouse_Left(1019, 650);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("2200");

            c.Mouse_Left(687, 705);
            Thread.Sleep(2000);
            c.Mouse_Left(746, 627);
            c.Mouse_Left(746, 627);
            Thread.Sleep(3000);
            ////--------------------------------------------

            //List data 4 
            c.Mouse_Left(1000, 250);
            Thread.Sleep(1000);
            c.Mouse_Left(1000, 270);
            Thread.Sleep(1000);

            c.Mouse_Left(958, 295);
            Thread.Sleep(1000);
            c.Mouse_Left(957, 314);
            Thread.Sleep(3000);

            ////----------------------------------------------
            c.Mouse_Left(1019, 455);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("VCI/00965");

            c.Mouse_Left(1019, 506);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("15/03/2018");

            c.Mouse_Left(1019, 558);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("75000");

            c.Mouse_Left(1019, 605);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("7500");

            c.Mouse_Left(1019, 650);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("82500");

            c.Mouse_Left(687, 705);
            Thread.Sleep(2000);
            c.Mouse_Left(746, 627);
            c.Mouse_Left(746, 627);
            Thread.Sleep(3000);
            ////--------------------------------------------

            //List data 5 

            c.Mouse_Left(1000, 250);
            Thread.Sleep(1000);
            c.Mouse_Left(1000, 270);
            Thread.Sleep(1000);

            c.Mouse_Left(958, 295);
            Thread.Sleep(1000);
            c.Mouse_Left(957, 314);
            Thread.Sleep(1000);

            ////----------------------------------------------
            c.Mouse_Left(1019, 455);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("VCI/01137");

            c.Mouse_Left(1019, 506);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("24/03/2018");

            c.Mouse_Left(1019, 558);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("34000");

            c.Mouse_Left(1019, 605);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("3400");

            c.Mouse_Left(1019, 650);
            Thread.Sleep(1000);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("37400");

            System.Windows.Forms.MessageBox.Show("Total amount is Not Matching, User Review requiered","Incorrect Value");
            Thread.Sleep(2000);
            SwitchToWinows("Incorrect Value");
            Thread.Sleep(1000);
            SwitchToWinows("Phenoix RPA Studio");
            //Thread.Sleep(5000)
            //Thread.Sleep(3000);
            ////--------------------------------------------

        }
        #region Find Window - Mian Logic

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
                    // MessageBox.Show("Found Window");

                    SwitchToThisWindow(ThisWindowPtr, true);
                }
            }
        }
        #endregion
    }
}
