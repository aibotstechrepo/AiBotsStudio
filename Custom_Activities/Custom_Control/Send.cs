using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows.Forms;


namespace Custom_Control
{
    public sealed class Send : CodeActivity
    {
        public InArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {        
            string text = context.GetValue(this.Text);
            if(text.Length > 0)
            {
                SendKeys.SendWait(text);
            }
            //SendKeys.SendWait(text);
        }
    }
}

