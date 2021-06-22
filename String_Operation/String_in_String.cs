using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_in_String : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("String to Search")]
        [RequiredArgument]
        public InArgument<string> SubText { get; set; }

        [Category("Input")]
        [DisplayName("Case Sensitive")]
        [DefaultValue(false)]
        public Boolean Case { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Position")]
        public OutArgument<Int32> Position { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string text = context.GetValue(this.Text);
                string subtext = context.GetValue(this.SubText);
                string text1 = text.ToUpper();
                string subtext1 = subtext.ToUpper();
                if (text1.Contains(subtext1) == true)
                {
                    int pos = -1;
                    //System.Windows.MessageBox.Show("contains");
                    if (Case == true)
                    {
                        //System.Windows.MessageBox.Show("true");
                        pos = text.IndexOf(subtext, StringComparison.CurrentCulture);
                    }
                    if (Case == false)
                    {
                        //System.Windows.MessageBox.Show("false");
                        pos = text.IndexOf(subtext, StringComparison.CurrentCultureIgnoreCase);
                        // pos = text.IndexOf(subtext);
                    }
                    
                    Position.Set(context, pos+1);
                    Result.Set(context, true);
                }
                else if (text1.Contains(subtext1) == false)
                {
                    Position.Set(context, 0);
                    Result.Set(context, false);

                }
            //}
            //catch
            //{
            //    ;
            //}

        }
    }
}
