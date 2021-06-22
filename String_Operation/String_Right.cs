using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Right : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Count")]
        [RequiredArgument]
        public InArgument<Int32> Count { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Output String")]
        public OutArgument<string> Output_String { get; set; }
         
        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{

                string a = context.GetValue(this.Text);
                int lastString = Convert.ToInt32(a.Length);
                int count = Convert.ToInt32(context.GetValue(this.Count));
            //if (count > 0)
           // {
                if (count <= lastString)
                {
                    string stringRht = a.Substring(lastString - count);
                    Output_String.Set(context, stringRht);
                    Result.Set(context, true);
                    //System.Windows.MessageBox.Show(stringRht);
                }
                else if (count >= lastString)
                {
                    Output_String.Set(context, a);
                    Result.Set(context, true);
                }
          // }

            //}
            //catch
            //{
            //    Output_String.Set(context, "");
            //    Result.Set(context, false);
            //}
        }
    }
}
