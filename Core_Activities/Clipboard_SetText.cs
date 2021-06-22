using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading;

namespace Core_Activities
{

    public sealed class Clipboard_SetText : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{ 
                string text = context.GetValue(this.Text);
                ClipboardSetText(text);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
        }
        private void ClipboardSetText(string inTextToCopy)
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
