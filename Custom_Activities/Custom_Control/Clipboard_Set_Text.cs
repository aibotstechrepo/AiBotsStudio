using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;

namespace Custom_Control
{

    public sealed class Clipboard_Set_Text : CodeActivity
    {
        public InArgument<string> Text_To_Set { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Text_To_Set);
            ClipboardSetText(text);
        }
        protected void ClipboardSetText(string inTextToCopy)
        {
            var clipboardThread = new Thread(() => ClipBoardThreadWorker(inTextToCopy));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }
        private void ClipBoardThreadWorker(string inTextToCopy)
        {
            System.Windows.Clipboard.SetText(inTextToCopy);
           
        }

    }
}
