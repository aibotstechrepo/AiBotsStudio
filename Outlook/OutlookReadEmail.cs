using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Outlook
{
    public sealed class OutlookReadEmail : CodeActivity
    {
        public InArgument<int> SelectOption { get; set; }
        public InArgument<string> Input1 { get; set; }
        public InArgument<string> Input2 { get; set; }
        public OutArgument<List<MailMessage>> Mails { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int option = context.GetValue(this.SelectOption);
            string input1 = context.GetValue(this.Input1);
            string input2 = context.GetValue(this.Input2);
            string error = null;
            try
            {
                List<MailMessage> mails = OutlookCore.ReadEmailThroughOUTLOOK(option, input1, input2);
                context.SetValue(Mails, mails);
            }
            catch (Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }
        }
    }
}
