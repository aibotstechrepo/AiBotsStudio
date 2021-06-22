using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Length : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Length")]
        public OutArgument<int> Output_String { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string text = context.GetValue(this.Text);
                int len = text.Length;
                Output_String.Set(context, len);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
           
        }
    }
}
