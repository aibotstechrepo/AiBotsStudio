using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using System.Windows;
using System.Threading;

namespace Core_Activities
{

    public sealed class Clipboard_Empty : CodeActivity
    {
       
        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                ClipboardEmptyText();
            }
            catch
            {
                ;
            }
            
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
