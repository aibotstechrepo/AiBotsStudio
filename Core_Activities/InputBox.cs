using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Core_Activities
{

    public sealed class InputBox : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Title")]
        [RequiredArgument]
        public InArgument<string> Title { get; set; }

        [Category("Input")]
        [DisplayName("Messaage")]
        [RequiredArgument]
        public InArgument<string> Messaage { get; set; }

        [Category("Input")]
        [DisplayName("Default Text")]
        public InArgument<string> Text { get; set; }

        [Category("Output")]
        [DisplayName("Output Value")]
        public OutArgument<string> outValue { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string title = context.GetValue(this.Title);
                string message = context.GetValue(this.Messaage);
                string text = context.GetValue(this.Text);

                string data = Microsoft.VisualBasic.Interaction.InputBox(message, title, text);
                outValue.Set(context, data);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }
    }
}
