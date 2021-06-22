using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows.Forms;
using System.ComponentModel;

namespace Custom_Control
{

    public sealed class Send_Control : CodeActivity
    {
        public enum Controls
        {
            CTRL,
            ALT,
            SHIFT
        }

        [Category("Input")]
        [RequiredArgument]
        public Controls Control { get; set; }

       // public InArgument<Controls> Control { get; set; }
        public InArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Text);
            if (text.Length < 2)
            {
                text = text.ToLower();
            }
            else
            {
                text = text.ToUpper();
            }

            string ctl = Convert.ToString(Control);
            MessageBox.Show(text);
            
            if(ctl == "CTRL")
            {
                SendKeys.SendWait("^" + text);
            }
            else if (ctl == "ALT")
            {
                SendKeys.SendWait("%" + text);
            }
            else if (ctl == "SHIFT")
            {
                SendKeys.SendWait("+" + text);
            }
            else
            {

            }
        }
    }
}
