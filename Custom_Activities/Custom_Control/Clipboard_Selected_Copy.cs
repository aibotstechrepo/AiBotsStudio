using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;
using System.Windows.Forms;
namespace Custom_Control
{
    public sealed class Clipboard_Selected_Copy : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Thread.Sleep(3000);
            SendKeys.SendWait("^c");
        }
    }
}
