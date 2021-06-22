using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;
using System.Windows.Forms;

namespace Custom_Control
{

    public sealed class Keyboard_Select_All : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            SendKeys.SendWait("^a");
        }
    }
}
