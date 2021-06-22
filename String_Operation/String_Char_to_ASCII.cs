using System;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Char_to_ASCII : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Char")]
        [RequiredArgument]
        public InArgument<char> charval { get; set; }


        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        
        [Category("Output")]
        [DisplayName("ASCII Code")] 
        public OutArgument<int> ASCII_Val { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                char charva = context.GetValue(this.charval);
                int asciiBytes = (int)charva;

                //System.Windows.MessageBox.Show(asciiBytes.ToString());
                ASCII_Val.Set(context, asciiBytes);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}

            


        }
    }
}
