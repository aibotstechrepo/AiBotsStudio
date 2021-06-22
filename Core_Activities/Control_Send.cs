using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Core_Activities
{

    public sealed class Control_Send : CodeActivity
    { 
        public enum ControlsFullList
        {
            none,
            Shift,
            Ctrl,
            Alt,
            Del,
            Tab,
            Insert,
            Backspace,
            Break,
            Enter,
            Esc,
            Home,
            End,
            Up_Arrow,
            Down_Arrow,
            Left_Arrow,
            Right_Arrow,
            Num_Lock,
            Caps_Lock,
            Scroll_Lock,
            Page_Up,
            Page_Down,
            Print_Screen,
            F1,
            F2,
            F3,
            F4,
            F5,
            F6,
            F7,
            F8,
            F9,
            F10,
            F11,
            F12,
            Keypad_Add,
            Keypad_Subtract,
            Keypad_Multiply,
            Keypad_Divide,
            Space,
            Win
        }

        [Category("Input")]
        [DisplayName("String")] 
        public InArgument<string> Text { get; set; }
         
        [Category("Input")]
        [DisplayName("Window Title")]
        public InArgument<string> Title { get; set; }

        [Category("Input")] 
        [DisplayName("Key Stroke 1")]
        public ControlsFullList Control1 { get; set; }

        [Category("Input")]
        [DisplayName("Key Stroke 2")]
        public ControlsFullList Control2 { get; set; }

        [Category("Input")]
        [DisplayName("Key Stroke 3")]
        public ControlsFullList Control3 { get; set; }

        [Category("Input")]
        [DisplayName("Key Stroke 4")]
        public ControlsFullList Control4 { get; set; }

        [Category("Input")]
        [DisplayName("Key Stroke 5")]
        public ControlsFullList Control5 { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }


        protected override void Execute(CodeActivityContext context)
        { 
            //try
            //{
                string text = context.GetValue(this.Text);
                
                
                int cont0 = Convert.ToInt32(Control1);
                int cont1 = Convert.ToInt32(Control2);
                int cont2 = Convert.ToInt32(Control3);
                int cont3 = Convert.ToInt32(Control4);
                int cont4 = Convert.ToInt32(Control5);
                string op ="";

                op = op + Control_Generate(cont0);
                op = op + Control_Generate(cont1);
                op = op + Control_Generate(cont2);
                op = op + Control_Generate(cont3);
                op = op + Control_Generate(cont4); 
                op = op + text;
                //System.Windows.MessageBox.Show(op);

                string win = context.GetValue(this.Title);
                if (string.IsNullOrEmpty(win) == false)
                {

                    SwitchToWinows(win);
                    SendKeys.SendWait(op);
                    System.Threading.Thread.Sleep(2000);
                    Result.Set(context, true);
                    //System.Windows.MessageBox.Show("hi" + res.ToString());
                    //Result.Set(context, res);
                }
                else
                {
                    SendKeys.SendWait(op);
                    Result.Set(context, true);
                }
            //}
            //catch
            //{ 
            //    Result.Set(context, false);
            //}

        }

        private string Control_Generate(int val)
        {
           // MessageBox.Show(val);
            int key = Convert.ToInt32(val);
            if(key == 0)
            {
                return ("");
            }
            else if(key == 1)
            {
                return ("+");
            }
            else if (key == 2)
            {
                return ("^");
            }
            else if (key == 3)
            {
                return ("%");
            }
            else if (key == 4)
            {
                return ("{DEL}");
            }
            else if (key == 5)
            {
                return ("{TAB}");
            }
            else if (key == 6)
            {
                return ("{INS}");
            }
            else if (key == 7)
            {
                return ("{BS}");
            }
            else if (key == 8)
            {
                return ("{BREAK}");
            }
            else if (key == 9)
            {
                return ("~");
            }
            else if (key == 10)
            {
                return ("{ESC}");
            }
            else if (key == 11)
            {
                return ("{HOME}");
            }
            else if (key == 12)
            {
                return ("{END}");
            }
            else if (key == 13)
            {
                return ("{UP}");
            }
            else if (key == 14)
            {
                return ("{DOWN}");
            }
            else if (key == 15)
            {
                return ("{LEFT}");
            }
            else if (key == 16)
            {
                return ("{RIGHT}");
            }
            else if (key == 17)
            {
                return ("{NUMLOCK}");
            }
            else if (key == 18)
            {
                return ("{CAPSLOCK}");
            }
            else if (key == 19)
            {
                return ("{SCROLLLOCK}");
            }
            else if (key == 20)
            {
                return ("{PGUP}");
            }
            else if (key == 21)
            {
                return ("{PGDN}");
            }
            else if (key == 22)
            {
                return ("{PRTSC}");
            }
            else if (key == 23)
            {
                return ("{F1}");
            }
            else if (key == 24)
            {
                return ("{F2}");
            }
            else if (key == 25)
            {
                return ("{F3}");
            }
            else if (key == 26)
            {
                return ("{F4}");
            }
            else if (key == 27)
            {
                return ("{F5}");
            }
            else if (key == 28)
            {
                return ("{F6}");
            }
            else if (key == 29)
            {
                return ("{F7}");
            }
            else if (key == 30)
            {
                return ("{F8}");
            }
            else if (key == 31)
            {
                return ("{F9}");
            }
            else if (key == 32)
            {
                return ("{F10}");
            }
            else if (key == 33)
            {
                return ("{F11}");
            }
            else if (key == 34)
            {
                return ("{F12}");
            }
            else if (key == 35)
            {
                return ("{ADD}");
            }
            else if (key == 36)
            {
                return ("{SUBTRACT}");
            }
            else if (key == 37)
            {
                return ("{MULTIPLY}");
            }
            else if (key == 38)
            {
                return ("{DIVIDE}");
            }
            else if (key == 39)
            {
                return (" ");
            }
            else if(key == 40)
            {
                return ("^({ESC}E)");
            }
            {
                return "";
            }
             
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
