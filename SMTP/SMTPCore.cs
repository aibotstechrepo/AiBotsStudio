using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using LogHandler;
using System.Threading.Tasks;

namespace SMTP
{
    public static class SMTPCore
    {
        public static bool Send(string HostName, string HostPort, string SenderEmailID, string[] To, string[] CC, string[] BCC, string Subject, string Body, string[] Attachments, string UserName, string Password)
        {
            try
            {
                LogHandle.ModuleLogFile("SMTP", "Send", "SMTP Started", "N", "39", null, null, "started");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(HostName, Convert.ToInt32(HostPort));
                mail.From = new MailAddress(SenderEmailID);

                if (To.Length > 0)
                {

                    foreach (var eachTo in To)
                    {
                        if (!String.IsNullOrWhiteSpace(eachTo))
                        {
                            mail.To.Add(eachTo);
                        }
                    }
                    LogHandle.ModuleLogFile("SMTP", "Send", "To List added", "N", "54", null, null, null);
                }
                if (CC.Length > 0)
                {
                    foreach (var eachCC in CC)
                    {
                        if (!String.IsNullOrWhiteSpace(eachCC))
                        {
                            mail.CC.Add(eachCC);
                        }
                    }
                    LogHandle.ModuleLogFile("SMTP", "Send", "CC List added", "N", "65", null, null, null);
                }

                if (BCC.Length > 0)
                {
                    foreach (var eachBCC in BCC)
                    {
                        if (!String.IsNullOrWhiteSpace(eachBCC))
                        {
                            mail.Bcc.Add(eachBCC);
                        }
                    }
                    LogHandle.ModuleLogFile("SMTP", "Send", "BCC List added", "N", "76", null, null, null);
                }
                if (!String.IsNullOrWhiteSpace(Subject))
                {
                    mail.Subject = Subject;
                }
                if (!String.IsNullOrWhiteSpace(Body))
                {
                    mail.Body = Body;
                }

                if (Attachments.Length > 0)
                {
                    LogHandle.ModuleLogFile("SMTP", "Send", "Attachment available", "N", "89", null, null, null);
                    foreach (var eachFile in Attachments)
                    {
                        if (!String.IsNullOrWhiteSpace(eachFile))
                        {
                            mail.Attachments.Add(new Attachment(eachFile));
                        }

                    }
                }
                SmtpServer.Port = Convert.ToInt32(HostPort);
                SmtpServer.Credentials = new System.Net.NetworkCredential(UserName, Password);
                SmtpServer.Send(mail);
                LogHandle.ModuleLogFile("SMTP", "Send", "Email Sent", "N", "89", null, null, null);
                return true;
            }
            catch (Exception ex)
            {
                LogHandle.ModuleLogFile("SMTP", "Send", "SMTP sending email", "Y", "107", ex.StackTrace, ex.ToString(), "Moving next");
            }
            return false;
        }
    }
}
