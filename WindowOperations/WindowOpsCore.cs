using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WindowOperations
{
    public class WindowOpsCore
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, int wParam, string lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint wMsg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        private const int SW_HIDDEN = 0;
        private const int SW_NORMAL = 1;
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
        {
            List<IntPtr> result = new List<IntPtr>();
            int ct = 0;
            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while (true && ct < maxCount)
            {
                currChild = FindWindowEx(hParent, prevChild, null, null);
                if (currChild == IntPtr.Zero) break;
                result.Add(currChild);
                prevChild = currChild;
                ++ct;
            }
            return result;
        }
        static IntPtr buttonhandle = IntPtr.Zero;
        [DllImport("User32.dll")]
        static extern Boolean EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);
        delegate int Callback(int hWnd, int lParam);
        static Callback myCallBack = new Callback(EnumChildGetValue);
        static List<IntPtr> classhandle = new List<IntPtr>();
        static int EnumChildGetValue(int hWnd, int lParam)
        {
            //string editText = "";
            StringBuilder ClassName = new StringBuilder(256);
            var nRet = GetClassName(new IntPtr(hWnd), ClassName, ClassName.Capacity);
            //Console.WriteLine("Control Caption : " + editText + " hWnd : " + hWnd + " Class Name : " + ClassName);
            classhandle.Add((IntPtr)hWnd);
            //Trace.WriteLine("Class Name : " + ClassName);
            return 1;
        }
        static string WinGetClassName(IntPtr Hwnd)
        {
            int Max_Length = GetWindowTextLength((IntPtr)Hwnd);
            string Build = "";
            StringBuilder builder = null;
            builder = new StringBuilder("", Max_Length + 100);
            GetClassName(Hwnd, builder, Max_Length + 100);
            Build = builder.ToString();
            return Build;
        }

        //Object Activities

        public static IntPtr GetHandle(string Title)
        {
            Process[] process = Process.GetProcesses();
            IntPtr Hand = IntPtr.Zero;
            foreach(var Proc in process)
            {
                if(Proc.MainWindowTitle == Title)
                {
                    Hand = Proc.MainWindowHandle;
                }
            }
            return Hand;
        }
        public static bool WinExists(string Title)
        {
            Process[] P = Process.GetProcesses();
            bool flag = false;
            foreach (var Proc in P)
            {
                if (Proc.MainWindowTitle == Title)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static void WinSetState(string Title, int State)
        {
            IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, Title);
            if (State == 1)
            {
                ShowWindow(hwnd, SW_HIDDEN);
            }
            else if (State == 2)
            {
                ShowWindow(hwnd, SW_MINIMIZE);
            }
            else if (State == 3)
            {
                ShowWindow(hwnd, SW_NORMAL);
            }
            else if (State == 4)
            {
                ShowWindow(hwnd, SW_MAXIMIZE);
            }
            else
            {
                throw new System.ArgumentException("Invalid State Number Provided Please Enter from (1 - 4)");
            }
        }
        public static object WinElement(string Title, string classname, int instance, string operation, string text)
        {
            var result = FindWindow(null, Title);
            EnumChildWindows(result, myCallBack, 0);
            int i = 0, j = 0;
            while (i < classhandle.Count)
            {
                if (WinGetClassName(classhandle[i]).ToLower() == classname.ToLower())
                {
                    j += 1;
                    if (j == instance)
                    {
                        buttonhandle = classhandle[i];
                        break;
                    }
                }
                i = i + 1;
            }
            classhandle.RemoveRange(0, classhandle.Count);
            if (operation.ToLower() == "click")
            {
                const uint WM_LClickDown = 0x0201;
                const uint WM_LClickUp = 0x0202;
                SendMessage(buttonhandle, WM_LClickDown, 0, 0x0001);
                SendMessage(buttonhandle, WM_LClickUp, 0, 0x0001);
                return true;
            }
            else if (operation.ToLower() == "focus")
            {
                const int WM_SetFocus = 0x0007;
                SendMessage(buttonhandle, WM_SetFocus, true, 0);
                return true;
            }
            else if (operation.ToLower() == "enable")
            {
                const int WM_Enable = 0x000A;
                SendMessage(buttonhandle, WM_Enable, true, 0);
                return true;
            }
            else if (operation.ToLower() == "disable")
            {
                const int WM_Enable = 0x000A;
                SendMessage(buttonhandle, WM_Enable, false, 0);
                return true;
            }
            else if (operation.ToLower() == "write")
            {
                const int WM_SETTEXT = 0X000C;
                SendMessage(buttonhandle, WM_SETTEXT, 0, text);
                return true;
            }
            else if (operation.ToLower() == "read")
            {
                const int WM_GETTEXT = 0X000D;
                const int WM_GETTEXTLENGTH = 0x000E;
                int txtLength = SendMessage(buttonhandle, WM_GETTEXTLENGTH, 0, "");
                StringBuilder sbText = new StringBuilder(txtLength + 1);
                SendMessage(buttonhandle, WM_GETTEXT, sbText.Capacity, sbText);
                text = sbText.ToString();
                return text;
            }
            else
            {
                return false;
            }
        }
        public static void WindowActivate(string Title)
        {
            Process[] process = Process.GetProcesses();
            foreach (var Proc in process)
            {
                if (Proc.MainWindowTitle == Title)
                {
                    IntPtr ptr = Proc.MainWindowHandle;
                    SetForegroundWindow(ptr);
                    ShowWindow(ptr, 9);
                }
            }
        }
        public static void WindowOpen(string Title, int WindowState)
        {
            ProcessStartInfo Pr = new ProcessStartInfo(Title);
            if (WindowState == 1)
            {
                Pr.WindowStyle = ProcessWindowStyle.Hidden;
            }
            else if (WindowState == 2)
            {
                Pr.WindowStyle = ProcessWindowStyle.Minimized;
            }
            else if (WindowState == 3)
            {
                Pr.WindowStyle = ProcessWindowStyle.Normal;
            }
            else if (WindowState == 4)
            {
                Pr.WindowStyle = ProcessWindowStyle.Maximized;
            }
            else
            {
                throw new System.ArgumentException("Invalid State Number Provided Please Enter from (1 - 4)");
            }
            Process.Start(Pr);
        }
    }
}
