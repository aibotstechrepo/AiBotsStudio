using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{ 
    public sealed class String_String_to_ASCII_IntArray : CodeActivity
    {
        [Category("Input")]
        [DisplayName("String")]
        [RequiredArgument]
        public InArgument<string> charval { get; set; } 

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; } 

        [Category("Output")]
        [DisplayName("ASCII Code")]
        public OutArgument<Int32[]> ASCII_Val { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string charva = context.GetValue(this.charval);
                int i = 0; 
                int[] res = new int[0];
                foreach (char c in charva)
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[i] = System.Convert.ToInt32(c);
                    //System.Windows.MessageBox.Show(c.ToString());
                    i++;
                }

                
                //System.Windows.MessageBox.Show(asciiBytes.ToString());
                ASCII_Val.Set(context, res);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }
    }
}
