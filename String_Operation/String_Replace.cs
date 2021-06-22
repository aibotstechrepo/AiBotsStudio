using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace String_Operation
{ 
    public sealed class String_Replace : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("String to Replace")]
        [RequiredArgument]
        public InArgument<string> Text_to_Find { get; set; }

        [Category("Input")]
        [DisplayName("New String")]
        [RequiredArgument]
        public InArgument<string> Replace_Text { get; set; }

        [Category("Input")]
        [DisplayName("Case Sensitive")]
        [DefaultValue(false)]
        public Boolean Case { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Output Text")]
        public OutArgument<string> Output_String { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
             
                string a = context.GetValue(this.Text);
                string b = context.GetValue(this.Text_to_Find);
                string c = context.GetValue(this.Replace_Text);
                string newval = "";

                //if (a.Contains(b))
                //{
                    if (Case == false)
                    {
                        newval = Regex.Replace(a, b, c, RegexOptions.IgnoreCase);
                    }
                    if (Case == true)
                    {
                        newval = a.Replace(b, c);
                    }
                //MessageBox.Show("String Found");
                
                Output_String.Set(context, newval);
                Result.Set(context, true);
                    //MessageBox.Show(newval);
                //}
                //else
                //{
                //    Output_String.Set(context, a);
                //    Result.Set(context, false);
                //    //MessageBox.Show("String not Found");
                //}
             

        }
    }
}
