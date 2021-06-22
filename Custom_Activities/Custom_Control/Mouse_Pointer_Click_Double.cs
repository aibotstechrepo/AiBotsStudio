using System;
using System.Activities;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Custom_Control
{
    public sealed class Mouse_Pointer_Click_Double : CodeActivity
    {
        public InArgument<int> X { get; set; }
        public InArgument<int> Y { get; set; }
        public InArgument<string> Windows_Title { get; set; }
        CustomFunction cf = new CustomFunction();
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        protected override void Execute(CodeActivityContext context)
        {
            int x = Convert.ToInt32(X.Get(context).ToString());
            int y = Convert.ToInt32(Y.Get(context).ToString());
            string text = context.GetValue(this.Windows_Title);
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
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new System.IntPtr());
        }
    }
}
