using System;
using System.Activities;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Custom_Control
{
    public sealed class Mouse_Pointer_Click_Left : CodeActivity
    {
        public InArgument<string> Windows_Title { get; set; }
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        CustomFunction cf = new CustomFunction();


        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Windows_Title);
            
            int x = Convert.ToInt32(X.Get(context).ToString());
            int y = Convert.ToInt32(Y.Get(context).ToString());
            try
            {
                cf.Close_Window(text);
                System.Threading.Thread.Sleep(500);
            }
            catch
            {

            }
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new System.IntPtr());
        }
    }
}
