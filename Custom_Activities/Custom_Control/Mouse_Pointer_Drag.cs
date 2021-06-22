using System;
using System.Activities;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
namespace Custom_Control
{
    public sealed class Mouse_Pointer_Drag : CodeActivity
    {
        public InArgument<int> X_From { get; set; }
        public InArgument<int> Y_From { get; set; }

        public InArgument<int> X_To { get; set; }
        public InArgument<int> Y_To { get; set; }
        public InArgument<string> Windows_Title { get; set; }
        CustomFunction cf = new CustomFunction();
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;


        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        protected override void Execute(CodeActivityContext context)
        {
            int x_F = Convert.ToInt32(X_From.Get(context).ToString());
            int y_F = Convert.ToInt32(Y_From.Get(context).ToString());

            int x_T = Convert.ToInt32(X_To.Get(context).ToString());
            int y_T = Convert.ToInt32(Y_To.Get(context).ToString());
            string text = context.GetValue(this.Windows_Title);
            try
            {
                cf.Close_Window(text);
                System.Threading.Thread.Sleep(500);
            }
            catch
            {

            }
           

            PointConverter pc = new PointConverter();

            Point pt = new Point();

            pt = (Point)pc.ConvertFromString(x_F + "," + y_F);

            Cursor.Position = pt;

            //Cursor.Position = new Point(x_F, y_F);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            Thread.Sleep(2000);
            pt = (Point)pc.ConvertFromString(x_T + "," + y_T);

            Cursor.Position = pt;
            //Cursor.Position = new Point(x_T, y_T);
            //Cursor.Position.X
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0,new System.IntPtr());
        }
    }
}
