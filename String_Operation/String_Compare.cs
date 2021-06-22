using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Activities.Presentation.PropertyEditing;
using System.Windows;

namespace String_Operation
{

    public sealed class String_Compare : CodeActivity
    {
        [Category("Input")]
        [DisplayName("String 1")]
        [RequiredArgument]
        public InArgument<string> Text1 { get; set; }
 
        [Category("Input")]
        [DisplayName("String 2")]
        [RequiredArgument]
        public InArgument<string> Text2 { get; set; }

        [Category("Input")]
        [DisplayName("Case Sensitive")] 
        public Boolean Case { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{

                string text1 = context.GetValue(this.Text1);
                string text2 = context.GetValue(this.Text2);
                if (Case == true)
                {
                    int a = string.Compare(text1, text2, false);
                    if (a == 0)
                    {
                        Result.Set(context, true);
                    }
                    else
                    {
                        Result.Set(context, false);
                    }

                }
                if (Case == false)
                {
                    int a = string.Compare(text1, text2, true);
                    if (a == 0)
                    {
                        Result.Set(context, true);
                    }
                    else
                    {
                        Result.Set(context, false);
                    }
                }
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }


    } 
}
