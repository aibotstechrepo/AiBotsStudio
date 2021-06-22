using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Left : CodeActivity
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
                int count = Convert.ToInt32(context.GetValue(this.Count));
            //if (count > 0)
            //{
                if (a.Length >= count)
                {
                    string stringLef = a.Substring(0, count);
                    Output_String.Set(context, stringLef);
                    Result.Set(context, true);
                }
                else if (a.Length <= count)
                {
                    
                    string stringLef = a.Substring(0, a.Length);
                    Output_String.Set(context, stringLef);
                    Result.Set(context, true);
                }
           // }
            //else
            //{
            //    Output_String.Set(context, "");
            //    Result.Set(context, false);
            //}


            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}

            
        }
    }
}
