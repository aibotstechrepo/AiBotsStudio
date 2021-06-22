using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Mail;
using Outlook1 = Microsoft.Office.Interop.Outlook;
using System.Text;
using System.Threading.Tasks;

namespace Outlook
{
    public static class OutlookCore
    {
        internal static Boolean SendEMailThroughOUTLOOK(string to, string subject, string body, string cc, string bcc)
        {
            try
            {
                //Create the Outlook application.
                Outlook1.Application oApp = new Outlook1.Application();
                // Create a new mail item.
                Outlook1.MailItem oMsg = (Outlook1.MailItem)oApp.CreateItem(Outlook1.OlItemType.olMailItem);
                oMsg.Subject = subject;
                //Console.WriteLine(oMsg.Subject);
                oMsg.To = to;
                //Console.WriteLine(oMsg.To);
                ////Add an attachment.
                String sDisplayName = "MyAttachment";
                int iPosition = (int)oMsg.Subject.Length + 1;
                int iAttachType = (int)Outlook1.OlAttachmentType.olByValue;
                ////now attached the file
                Outlook1.Attachment oAttach = oMsg.Attachments.Add
                                           ("C:\\Users\\bharath.g.AIBOTS\\Desktop\\BASIC_PROGRAMS\\Help_File-1-DOC-12-3-18.pdf", iAttachType, iPosition, sDisplayName);
                oMsg.Body = body;
                //cc
                oMsg.CC = cc;
                //bcc
                oMsg.BCC = bcc;
                //Console.WriteLine(oMsg.Body);
                oMsg.Importance = Outlook1.OlImportance.olImportanceLow;
                ((Outlook1.MailItem)oMsg).Send();
                return true;
            }
            catch
            {
                Console.WriteLine("Operation Failed");
            }
            return false;
        }//END OF EMAIL METHOD
        internal static List<MailMessage> ReadEmailThroughOUTLOOK(int select_opt, string input_val, string input_val1)
        {
            //File path to save attachments
            string file_path = @"C:\Users\bharath.g.AIBOTS\Desktop\C#\24-09-2019";
            if (!Directory.Exists(file_path))
            {
                //Creates a directory if not exists
                Directory.CreateDirectory(file_path);
            }
            //Read All
            if (select_opt == 0)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                Outlook1.Items item = null;
                Outlook1.MAPIFolder inboxFolder = null;
                //Outlook1.MAPIFolder subFolder = null;
                //Outlook1.MailItem mail1 = null;
                int i = 0;
                try
                {
                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    //Read All
                    item = inboxFolder.Items;
                    List<MailMessage> Emails = new List<MailMessage>();
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in item)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Reading*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //string from_address = Coreoperation.getfromaddress(mail1);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //CC
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                    //return (Outlook1.Items)item;
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }
            }

            // Read From
            if (select_opt == 1)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                Outlook1.Items items = null;
                Outlook1.MAPIFolder inboxFolder = null;
                int i = 0;
                try
                {
                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    string sCriteria = "[SenderEmailAddress]= '" + input_val + "'";
                    //string sCriteria = "[From]= '" + input_val + "'";
                    items = inboxFolder.Items.Restrict(sCriteria.ToString());
                    List<MailMessage> Emails = new List<MailMessage>();
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Reading*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //string from_address = Coreoperation.getfromaddress(mail1);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //CC
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }

            }

            // Read String
            if (select_opt == 2)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                //Outlook1._MailItem oMICopy = null;
                Outlook1.Items items = null;
                Outlook1.MAPIFolder inboxFolder = null;
                //Outlook1.Search advancedsearch = null;
                //Outlook1.Results advancedsearchresults = null;
                List<MailMessage> Emails = new List<MailMessage>();
                int i = 0;
                try
                {
                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

                    //Read Body
                    string filter;
                    string phrase_match = " ci_phrasematch '" + input_val + "'";
                    if (app.Application.Session.DefaultStore.IsInstantSearchEnabled)
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:textdescription" + "\""
                        + phrase_match;
                    }
                    else
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:textdescription" + "\""
                        + " like '%" + input_val + "%'";
                    }
                    items = inboxFolder.Items.Restrict(filter);
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            //Console.WriteLine("************Mail Body*************");
                            //Console.WriteLine(mail1.To);
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //Cc
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }

                            Emails.Add(mail);
                        }
                    }

                    //Read Subject
                    if (app.Application.Session.DefaultStore.IsInstantSearchEnabled)
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:subject" + "\""
                        + phrase_match;
                    }
                    else
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:subject" + "\""
                        + " like '%" + input_val + "%'";
                    }
                    //Console.WriteLine(filter);
                    items = inboxFolder.Items.Restrict(filter);
                    //Console.WriteLine("****************Mail S*************");
                    //Console.WriteLine("subject count" + items.Count);
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Subject*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //Cc
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }

                    //From
                    filter = "[From]= '" + input_val + "'";
                    items = inboxFolder.Items.Restrict(filter);
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (Outlook1.MailItem mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            //Console.WriteLine("************Mail From*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //Cc
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }

                    //Read TO
                    filter = "[To]= '" + input_val + "'";
                    items = inboxFolder.Items.Restrict(filter);
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (Outlook1.MailItem mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            //Console.WriteLine("************Mail To*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //Cc
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    //Console.WriteLine(Emails.Count);
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }

            }

            // Read Subject
            if (select_opt == 3)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                Outlook1.Items items = null;
                Outlook1.MAPIFolder inboxFolder = null;
                int i = 0;
                try
                {

                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    string filter;
                    string phrase_match = " ci_phrasematch '" + input_val + "'";
                    if (app.Application.Session.DefaultStore.IsInstantSearchEnabled)
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:subject" + "\""
                        + phrase_match;
                    }
                    else
                    {
                        filter = "@SQL=" + "\""
                        + "urn:schemas:httpmail:subject" + "\""
                        + " like '%" + input_val + "%'";
                    }
                    items = inboxFolder.Items.Restrict(filter.ToString());
                    List<MailMessage> Emails = new List<MailMessage>();
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Reading*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //string from_address = Coreoperation.getfromaddress(mail1);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //CC
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }

            }


            // Read Date_Of_Recieve
            if (select_opt == 4)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                Outlook1.Items items = null;
                Outlook1.MAPIFolder inboxFolder = null;
                int i = 0;
                try
                {

                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    string sCriteria = "[ReceivedTime] >= '" + input_val + "'";
                    //sCriteria = "[ReceivedTime] >=" + '08/08/2019' AND [ReceivedTime] <= '11/09/2019'";
                    sCriteria = "[ReceivedTime]>='" + input_val + "' AND [ReceivedTime] <='" + input_val1 + "'";
                    items = inboxFolder.Items.Restrict(sCriteria.ToString());
                    List<MailMessage> Emails = new List<MailMessage>();
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Reading*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //string from_address = Coreoperation.getfromaddress(mail1);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //CC
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }

            }

            // Has Attachment
            if (select_opt == 5)
            {
                Outlook1.Application app = null;
                Outlook1._NameSpace ns = null;
                Outlook1.Items items = null;
                Outlook1.MAPIFolder inboxFolder = null;
                int i = 0;
                try
                {
                    app = new Microsoft.Office.Interop.Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    ns.Logon(null, null, false, false);
                    inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
                    string sCriteria = "[Attachment]= '" + input_val + "'";
                    //sCriteria = "[ReceivedTime] >=" + '08/08/2019' AND [ReceivedTime] <= '11/09/2019'";
                    //sCriteria = "[ReceivedTime]>='" + strt_date + "' AND [ReceivedTime] <='" + end_date + "'";
                    items = inboxFolder.Items.Restrict(sCriteria.ToString());
                    List<MailMessage> Emails = new List<MailMessage>();
                    //Console.WriteLine("****************Mail Subject*************");
                    foreach (dynamic mail1 in items)
                    {
                        if (mail1 is Outlook1.MailItem)
                        {
                            // Console.WriteLine("************Mail Reading*************");
                            MailMessage mail = new MailMessage();
                            //From
                            mail.Sender = new MailAddress(mail1.SenderEmailAddress);
                            //string from_address = Coreoperation.getfromaddress(mail1);
                            //To
                            mail.To.Add(new MailAddress(mail1.ReceivedByName));
                            //Subject
                            mail.Subject = mail1.Subject;
                            //Body
                            mail.Body = mail1.Body;
                            //CC
                            if (mail1.CC == "")
                                mail.CC.Add("none@xyz.com");
                            else
                                mail.CC.Add(mail1.CC);
                            //Attachments
                            if (mail1.Attachments.Count > 0)
                            {
                                for (i = 1; i <= mail1.Attachments.Count; i++)
                                {
                                    string filepath1 = Path.Combine(file_path, mail1.Attachments[i].FileName);
                                    //Console.WriteLine(filepath1);
                                    mail1.Attachments[i].SaveAsFile(filepath1);
                                    string file_info = filepath1;
                                    Attachment mail_mssg = new Attachment(filepath1);
                                    //Add the Attachment
                                    mail.Attachments.Add(mail_mssg);
                                    mail_mssg.Dispose();
                                }
                                i = 1;
                            }
                            Emails.Add(mail);
                        }
                    }
                    return Emails;
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    ns = null;
                    app = null;
                    inboxFolder = null;
                }
            }
            return (List<MailMessage>)null;
        }
    }
}
