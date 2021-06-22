using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Trim_WS : CodeActivity
    {
        [Category("Input")]
        [DisplayName("String to trim")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Trim Left")]
        [DefaultValue(false)]
        public Boolean Trim_Left { get; set; }

        //[Category("Input")]
        //[DisplayName("Trim")]
        //[DefaultValue(true)]
        //public Boolean Trim_Both { get; set; }

        [Category("Input")]
        [DisplayName("Trim Right")]
        [DefaultValue(false)]
        public Boolean Trim_Right { get; set; }

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
                string text = context.GetValue(this.Text);

                string outVal = "";
                 
                //if(Trim_Both == true)
                //{
                //    outVal = text.Trim();
                //}

                if (Trim_Left == true && Trim_Right == false)
                {
                    outVal = text.TrimStart();
                }
                else if (Trim_Right == true && Trim_Left == false)
                {
                    outVal = text.TrimEnd();
                }
                else if (Trim_Right == false && Trim_Left == false)
                {
                    outVal = text.Trim();
                }
                else
                {
                    outVal = text.Trim();
                }

                Output_String.Set(context, outVal);
                Result.Set(context, true);

                //System.Windows.MessageBox.Show(text.Length.ToString());
                //System.Windows.MessageBox.Show(outVal.Length.ToString());
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }
    }
}
