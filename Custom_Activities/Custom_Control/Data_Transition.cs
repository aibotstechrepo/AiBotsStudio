using System;
using System.Activities;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Custom_Control
{
    class Data_Transition
    {
        // CustomFunction obj1 = new CustomFunction();
        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        public void Mouse_Left(int X, int Y)
        {
            int x = X;
            int y = Y;
            Cursor.Position = new Point(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new System.IntPtr());
        }
    







    public string Array_to_String(string[] Array_data)
        {
            string String_Result = "";
            int i = 0;
            foreach(string data in Array_data)
            {
                if(i == 0)
                {
                    String_Result = data;
                    i = 2;
                }
                else
                { 
                    String_Result = String_Result + ":::" + data;
                }
            }
            return String_Result;
        }

        //public string[] String_to_Array(string String_data)
        //{
        //    string[] Array_Result = new string[0];
        //    int size = obj1.String_split_newLine(String_data, ":::").Length;
        //    Array.Resize(ref Array_Result, size);
        //    Array_Result = obj1.String_split_newLine(String_data, ":::");
        //    return Array_Result;
        //}
    }
}
