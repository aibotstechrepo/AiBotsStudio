using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class String_Between : CodeActivity
    { 
        public InArgument<string> Input_String { get; set; }
        public InArgument<string> String_From { get; set; }
        public InArgument<string> String_To { get; set; }
        public OutArgument<string> Out_Array_String { get; set; }
 
        protected override void Execute(CodeActivityContext context)
        {
            
            string input = context.GetValue(this.Input_String);
            string delimeter = "\n";
            string delimeter1 = context.GetValue(this.String_From);
            string delimeter2 = context.GetValue(this.String_To);
            
            String St = input;

            string fil = "";

            string[] filter = input.Split(new string[] { delimeter }, StringSplitOptions.None);
            string[] data = new string[0];
            foreach (string s in filter)
            {
                int pFrom = s.IndexOf(delimeter1) + delimeter1.Length;
                int pTo = s.LastIndexOf(delimeter2);


                int t = data.Length;
                //MessageBox.Show(t.ToString());
                Array.Resize(ref data, t + 1);
                t = data.Length;
                //MessageBox.Show(t.ToString());
                //MessageBox.Show("pFrom : " + pFrom + "\n" + "pTo : " + pTo);
                fil = s.Substring(pFrom, pTo - pFrom);
                data[t - 1] = fil;
                System.Windows.MessageBox.Show(fil);

            }
            Out_Array_String.Set(context, fil);
            //Out_Array_String.Set(context, data);
            ////foreach (String s in data)
            ////{
            ////    MessageBox.Show(s);
            ////}
        }
    }
}
