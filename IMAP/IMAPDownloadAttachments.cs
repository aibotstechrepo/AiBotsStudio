using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace IMAP
{
    public sealed class IMAPDownloadAttachments : CodeActivity
    {
        public InArgument<string> Server { get; set; }
        public InArgument<int> Port { get; set; }
        public InArgument<string> UserName { get; set; }
        public InArgument<string> Password { get; set; }
        public InArgument<string> AttachmentSaveLocation { get; set; }
        public OutArgument<string[]> Attachments { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string server = context.GetValue(this.Server);
            int port = context.GetValue(this.Port);
            string username = context.GetValue(this.UserName);
            string password = context.GetValue(this.Password);
            string location = context.GetValue(this.AttachmentSaveLocation);
            string error = null;
            try
            {
                string attachments = IMAPCore.DowloadAttachment(server, port, username, password, location);
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
