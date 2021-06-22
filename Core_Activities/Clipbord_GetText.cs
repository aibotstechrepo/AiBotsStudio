using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading;

namespace Core_Activities
{

    public sealed class Clipbord_GetText : CodeActivity
    {
        [Category("Output")]
        [DisplayName("Text")]
        [RequiredArgument]
        public OutArgument<string> Text { get; set; }

        public string temp = "";

        protected override void Execute(CodeActivityContext context)
        {
            int Len = -1;
            int count = 0;
            ClipboardGetText();
            int flg = 0;
            while (Len < 3)
            {
                Len = Convert.ToInt32(temp.Length); 
                if (Len > 1)
                {
                    Text.Set(context, temp); 
                    break;
                }
                else
                { 
                    if (count >= 5)
                    {
                        count = 0; 
                        Thread.Sleep(3500);
                        flg = flg + 1;
                    }
                }
                if(flg>=2)
                {
                    Text.Set(context, temp);
                    break;
                }
                count++;
            }
        }

        private void ClipboardGetText()
        {
            var clipboardThread = new Thread(() => ClipBoardThreadWorker());
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();

        }
        private void ClipBoardThreadWorker()
        {
            string a = System.Windows.Clipboard.GetText();
            
            temp = a;
        }



    }
}
