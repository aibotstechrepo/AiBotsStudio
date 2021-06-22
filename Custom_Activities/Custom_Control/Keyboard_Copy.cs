using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;
using System.Windows.Forms;

namespace Custom_Control
{

    public sealed class Keyboard_Copy : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            ClipboardEmptyText();
            System.Threading.Thread.Sleep(300);
            SendKeys.SendWait("^c");
        }
        private void ClipboardEmptyText()
        {
            var clipboardThread = new Thread(() => ClipBoardThreadWorker());
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }
        private void ClipBoardThreadWorker()
        {
            System.Windows.Clipboard.Clear();
        }
    }
}
