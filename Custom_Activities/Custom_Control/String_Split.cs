using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class String_Split : CodeActivity
    {
        public InArgument<string> Text { get; set; }
        public InArgument<string> Delimiter_Char { get; set; }
        public OutArgument<string> data { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Text);
            string delimiter = context.GetValue(this.Delimiter_Char);

            if (delimiter.Length > 0 && delimiter.Length < 2)
            {
                char d1 = Convert.ToChar(delimiter);
                //string NewSplit = text.Split(d1);
                string NewSplit = "";
                data.Set(context, NewSplit);
                //foreach (string a in NewSplit)
                //{
                //    System.Windows.MessageBox.Show(a);

                //}
            }

        }
    }
}
