using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading;
using System.ComponentModel;
//using System.Runtime.InteropServices.ComTypes;
using System.Windows;

namespace Custom_Control
{
    
    public sealed class Clipboard_Get_Text : CodeActivity
    { 
        [Category("Output")]
        public OutArgument<string> Get_Text
        {
            get; set;
        }
        public string temp = "";

        protected void ClipboardGetText()
        {
            var clipboardThread = new Thread(() => ClipBoardThreadWorker());
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();

        }
        private void ClipBoardThreadWorker()
        {
            System.Windows.Forms.IDataObject ClipData = System.Windows.Forms.Clipboard.GetDataObject();

            if (ClipData.GetDataPresent(DataFormats.Text))
            {
                string s = System.Windows.Forms.Clipboard.GetData(DataFormats.Text).ToString();
                temp = s;
            }
            //string a = System.Windows.Clipboard.GetText();

            //string a= System.Windows.Clipboard.GetText();
            // System.Windows.MessageBox.Show("Loop 1 " + a);
            //temp = a;
            //System.Windows.MessageBox.Show("Transferred : " + temp);
        }
        //[STAThread]
        protected override void Execute(CodeActivityContext context)
        {
            int Len = -1;
            int count = 0;
            ClipboardGetText();
            while(Len < 3)
            {
                Len = Convert.ToInt32(temp.Length);
               // MessageBox.Show("Len : " + Len + "  -   Count " + count);
                if (Len >  1 )
                {
                    //MessageBox.Show("data captured : Data is : " + temp);
                    Get_Text.Set(context, temp);
                    break;
                }
                else
                {
                   // MessageBox.Show("else ");
                    if(count >= 5)
                    {
                        count = 0;
                        //MessageBox.Show("sleeping");
                        Thread.Sleep(3000);
                    }
                }
                count++;
            }

            //System.Windows.MessageBox.Show("data out: no initialtized");


        




        //string temp;
        //temp= System.Windows.Forms.Clipboard.GetText();
        //System.Windows.MessageBox.Show(temp);


        //IDataObject idat = null;
        //Exception threadEx = null;
        //Thread staThread = new Thread(
        //    delegate ()
        //    {
        //        try
        //        {
        //            idat = Clipboard.GetDataObject();
        //        }

        //        catch (Exception ex)
        //        {
        //            threadEx = ex;  
        //        }
        //    });
        //staThread.SetApartmentState(ApartmentState.STA);
        //staThread.Start();
        //staThread.Join();
        //MessageBox.Show(idat.ToString());
        //MessageBox.Show(threadEx.ToString());


    }



    }
}
