using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_AlphaNumeric : CodeActivity
    {
        [Category("Input")]
        [DisplayName("String to Check")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Alphabet")]
        [DefaultValue(false)]
        public Boolean IsAplpha { get; set; }

        [Category("Input")]
        [DisplayName("Numeric")]
        [DefaultValue(false)]
        public Boolean IsNumber { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{

                string text = context.GetValue(this.Text);
                bool data = false;


                if (IsAplpha == false && IsNumber == false)
                {
                    data = text.All(char.IsLetterOrDigit);
                    //data = true;
                }
                else if (IsAplpha == true && IsNumber == false)
                {
                    data = text.All(char.IsLetter);
                }
                else if (IsAplpha == false && IsNumber == true)
                {
                    data = text.All(char.IsDigit);
                }
                else if (IsAplpha == true && IsNumber == true)
                {
                    data = text.All(char.IsLetterOrDigit);
                }
                else
                {
                    data = false;
                }
                //System.Windows.MessageBox.Show(data.ToString());
                Result.Set(context, data);
            //}
            //catch
            //{
            //    ;
            //}


            //bool data = text.All(char.IsDigit);
            //System.Windows.MessageBox.Show(data.ToString());
        }
    }
}
