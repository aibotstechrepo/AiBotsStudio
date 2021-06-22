using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_ASCII_to_Char : CodeActivity
    {
        [Category("Input")]
        [DisplayName("ASCII Code")]
        [RequiredArgument]
        public InArgument<int> ASCII_Val { get; set; }
        
        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Char Value")]
        public OutArgument<char> charval { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                int val = context.GetValue(this.ASCII_Val);
                char c = Convert.ToChar(val);
                //System.Windows.MessageBox.Show(c.ToString());
                charval.Set(context, c);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }
    }
}
