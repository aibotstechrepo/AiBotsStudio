using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace SMTP
{
    public sealed class SMTPSend : CodeActivity
    {
        public InArgument<string> HostName { get; set; }
        public InArgument<string> HostPort { get; set; }
        public InArgument<string> SenderEmailID { get; set; }
        public InArgument<string[]> To { get; set; }
        public InArgument<string[]> CC { get; set; }
        public InArgument<string[]> BCC { get; set; }
        public InArgument<string> Subject { get; set; }
        public InArgument<string> Body { get; set; }
        public InArgument<string[]> Attachments { get; set; }
        public InArgument<string> UserName { get; set; }
        public InArgument<string> Password { get; set; }
        public OutArgument<bool> Status { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string host = context.GetValue(this.HostName);
            string port = context.GetValue(this.HostPort);
            string senderid = context.GetValue(this.SenderEmailID);
            string[] to = context.GetValue(this.To);
            string[] cc = context.GetValue(this.CC);
            string[] bcc = context.GetValue(this.BCC);
            string subject = context.GetValue(this.Subject);
            string body = context.GetValue(this.Body);
            string[] attachments = context.GetValue(this.Attachments);
            string username = context.GetValue(this.UserName);
            string password = context.GetValue(this.Password);
            string error = null;
            try
            {
                bool status = SMTPCore.Send(host, port, senderid, to, cc, bcc, subject, body, attachments, username, password);
                context.SetValue(Status, status);
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
