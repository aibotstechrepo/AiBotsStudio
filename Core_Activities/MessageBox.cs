using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;

namespace Core_Activities
{

    public sealed class MessageBox : CodeActivity
    {
        public enum btn
        {
            Ok,
            OK_Cancel,
            Yes_No,
            Yes_No_Cancel,
            Abort_Retry_Ignore,
            Retry_Cancel,
        }
        public enum img
        {
            None,
            Information,
            Question,
            Warning,
            Stop
        }
        public enum dfbtn
        { 
            Button1,
            Button2,
            Button3 
        }

        [Category("Input")]
        [DisplayName("Button")]
        public btn  bt { get; set; }

        [Category("Input")]
        [DisplayName("Default Button")]
        public dfbtn bdt { get; set; }

        [Category("Input")]
        [DisplayName("Icon")]
        public img ic { get; set; }

        [Category("Input")]
        [DisplayName("Title")]
        public InArgument<string> tit { get; set; }

        [Category("Input")]
        [DisplayName("Message")]
        public InArgument<string> msg { get; set; }

        [Category("Output")]
        [DisplayName("Button Value")]
        public OutArgument<int> BtnResVal { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

      

        /// <summary> //referece
        /*          Information	    64          The message box contains a symbol consisting of a lowercase letter i in a circle.
         *          None	        0	        No icon is displayed.
         *          Question	    32	        The message box contains a symbol consisting of a question mark in a circle.
         *          Stop	        16	        The message box contains a symbol consisting of white X in a circle with a red background.
         *          Warning	        48	        The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
         *          
         *          
         *          
         *          Cancel	2	The result value of the message box is Cancel.
         *          No	    7	The result value of the message box is No.
         *          None	0	The message box returns no result.
         *          OK	    1	The result value of the message box is OK.
         *          Yes	    6	The result value of the message box is Yes.
         *          
         *          
         *           Ok             0           The message box displays an OK button.
                     OKCancel	    1	        The message box displays OK and Cancel buttons.
                     YesNo          4	        The message box displays Yes and No buttons.
                     YesNoCancel    3          The message box displays Yes, No, and Cancel buttons.    
        */
        /// </summary> 

        protected override void Execute(CodeActivityContext context)
        {
            int btn = Convert.ToInt32(bt);
            MessageBoxButtons btnval = MessageBoxButtons.OK;

            int img = Convert.ToInt32(ic);
            MessageBoxIcon imgval = MessageBoxIcon.None;

            int dfbtns = Convert.ToInt32(bdt);
            MessageBoxDefaultButton dfbtnsval = MessageBoxDefaultButton.Button1;

            string title = context.GetValue(this.tit);
            string message = context.GetValue(this.msg);
             
            DialogResult resval = DialogResult.None;

            int res = 0;
            
 
            if(btn == 0 )
            {
                btnval = MessageBoxButtons.OK;
            }
            else if(btn == 1)
            {
                btnval = MessageBoxButtons.OKCancel;
            }
            else if (btn == 2)
            {
                btnval = MessageBoxButtons.YesNo;
            }
            else if (btn == 3)
            {
                btnval = MessageBoxButtons.YesNoCancel;
            }
            else if (btn == 4)
            {
                btnval = MessageBoxButtons.AbortRetryIgnore;
            }
            else if (btn == 5)
            {
                btnval = MessageBoxButtons.RetryCancel;
            }
            else
            {
                btnval = MessageBoxButtons.OK;
            }


            if (img == 0)
            {
                imgval = MessageBoxIcon.None;
            }
            else if (img == 1)
            {
                imgval = MessageBoxIcon.Information;
            }
            else if (img == 2)
            {
                imgval = MessageBoxIcon.Question;
            }
            else if (img == 3)
            {
                imgval = MessageBoxIcon.Exclamation;
            }
            else if(img == 4)
            {
                imgval = MessageBoxIcon.Stop;
            }
            else  
            {
                imgval = MessageBoxIcon.None;
            }

            if(dfbtns == 0)
            {
                dfbtnsval = MessageBoxDefaultButton.Button1;
            }
            else if (dfbtns == 1)
            {
                dfbtnsval = MessageBoxDefaultButton.Button2;
            }
            else if (dfbtns == 2)
            {
                dfbtnsval = MessageBoxDefaultButton.Button3;
            }
            else
            {
                dfbtnsval = MessageBoxDefaultButton.Button1;
            }



            //try
            //{
                resval = System.Windows.Forms.MessageBox.Show(message, title, btnval, imgval, dfbtnsval);
                if(resval == DialogResult.None)
                {
                    res = 0;
                }
                else if (resval == DialogResult.OK)
                {
                    res = 1;
                }
                else if (resval == DialogResult.Cancel)
                {
                    res = 2;
                }
                else if (resval == DialogResult.Yes)
                {
                    res = 3;
                }
                else if (resval == DialogResult.No)
                {
                    res = 4;
                }
                else if (resval == DialogResult.Retry)
                {
                    res = 5;
                }
                else if (resval == DialogResult.Abort)
                {
                    res = 6;
                }
                else if (resval == DialogResult.Ignore)
                {
                    res = 7;
                }
                else 
                {
                    res = 0;
                }

                BtnResVal.Set(context, res);
                Result.Set(context, true);

            //}
            //catch
            //{ 
            //    BtnResVal.Set(context, res);
            //    Result.Set(context, false);
            //}

           
        }
    }
}
