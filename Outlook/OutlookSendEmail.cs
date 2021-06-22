using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Outlook
{
    public sealed class OutlookSendEmail : CodeActivity
    {
        public InArgument<string> To { get; set; }
        public InArgument<string> Subject { get; set; }
        public InArgument<string> Body { get; set; }
        public InArgument<string> CC { get; set; }
        public InArgument<string> BCC { get; set; }
        public OutArgument<bool> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string to = context.GetValue(this.To);
            string subject = context.GetValue(this.Subject);
            string body = context.GetValue(this.Body);
            string cc = context.GetValue(this.CC);
            string bcc = context.GetValue(this.BCC);
            string error = null;
            try
            {
                bool output = OutlookCore.SendEMailThroughOUTLOOK(to, subject, body, cc, bcc);
                context.SetValue(Output, output);
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
