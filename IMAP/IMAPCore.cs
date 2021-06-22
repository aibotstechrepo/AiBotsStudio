using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.IO;
using LogHandler;

namespace IMAP
{
    public static class IMAPCore
    {
        public static string DowloadAttachment(string server, int port, string userName, string password, string attachmentSaveLocation)
        {
            string ErrorReport = null;
            int dairy_trend_report_counter = 0, fresh_dairy_stock_ageing_report_counter = 0, crates_report_bihar_counter = 0, crates_report_wb_counter = 0, fresh_dairy_sales_summary_report_counter = 0, fresh_dairy_sales_report_counter = 0, crates_report_aasma_counter = 0, crates_report_munger_counter = 0;
            int dairy_trend_report_counter_zip = 0, fresh_dairy_stock_ageing_report_counter_zip = 0, crates_report_bihar_counter_zip = 0, crates_report_wb_counter_zip = 0, fresh_dairy_sales_summary_report_counter_zip = 0, fresh_dairy_sales_report_counter_zip = 0, crates_report_aasma_counter_zip = 0, crates_report_munger_counter_zip = 0;

            string salesTrendReportPattern = "daily sales trend";                 //1
            string productAgeingReportPattern = "stock ageing report";     //2
            string crateReportBiharPattern = "ada - crates security balance - bihar";                    //3
            string crateReportWBPattern = "ada - crates security balance - wb";                    //3
            string crateReportaasmaPattern = "ada -  outstanding crates - aasma";                    //3
            string crateReportmungerPattern = "ada -  outstanding crates - munger";                    //3
            string salesReportSummaryPattern = "sales summary";      //4
            string salesReportPattern = "ada - outstanding balances";

            try
            {
                using (var client = new ImapClient())
                {
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "IMAP Started", "N", "39", null, null, "started");

                    // For demo-purposes, accept all SSL certificates
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(server, port, false);

                    client.Authenticate(userName, password);

                    // The Inbox folder is always available on all IMAP servers...
                    //var inbox = client.Inbox;
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    MimeMessage message;
                    SearchQuery query = null;
                    query = SearchQuery.All;

                    foreach (UniqueId uid in inbox.Search(query))
                    {
                        try
                        {

                            LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "IMAP Loaded all messages", "N", "61", null, null, null);
                            message = inbox.GetMessage(uid);
                            string MessageDate = message.Date.ToString("dd/MM/yy");
                            string CompareDate = DateTime.Now.ToString("dd/MM/yy");
                            //string MessageDate = message.Date.ToString("MM/dd/yyyy");
                            //string CompareDate = DateTime.Now.ToString("MM/dd/yyyy");
                            DateTime MessageDateCompare = Convert.ToDateTime(MessageDate);
                            DateTime CompareDateCompare = Convert.ToDateTime(CompareDate);
                            if (MessageDateCompare == CompareDateCompare)
                            {
                                LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "IMAP mail found for today", "N", "71", null, null, null);
                                string MessageSubject = message.Subject;
                                LogHandle.ModuleLogFile("IMAP", MessageSubject, "IMAP mail found for today", "N", "71", null, null, null);
                                bool check = false;
                                if (MessageSubject.Length > 4)
                                {
                                    string str = MessageSubject.Trim().Substring(0, 1).ToLower().Trim();
                                    if (str.Contains("re") || str.Contains("fw"))
                                    {
                                        LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Found Replied or Forwarded Message. Hence ignored", "N", "79", null, null, null);
                                        // Replyed or Forwarded Email. Hence ignored.
                                    }
                                    else
                                    {

                                        LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Found Mail.", "N", "85", null, null, null);
                                        check = true;
                                    }
                                }

                                if (check) // Process data for Today date.
                                {
                                    #region Replace non file storeable char
                                    if (MessageSubject.Contains(@"\"))
                                    {
                                        MessageSubject.Replace(@"\", " ");
                                    }
                                    if (MessageSubject.Contains(@"/"))
                                    {
                                        MessageSubject.Replace(@"/", " ");
                                    }
                                    if (MessageSubject.Contains(@":"))
                                    {
                                        MessageSubject.Replace(@":", " ");
                                    }
                                    if (MessageSubject.Contains(@"*"))
                                    {
                                        MessageSubject.Replace(@"*", " ");
                                    }
                                    if (MessageSubject.Contains(@"?"))
                                    {
                                        MessageSubject.Replace(@"?", " ");
                                    }
                                    if (MessageSubject.Contains("\""))
                                    {
                                        MessageSubject.Replace("\"", " ");
                                    }
                                    if (MessageSubject.Contains(@"<"))
                                    {
                                        MessageSubject.Replace(@"<", " ");
                                    }
                                    if (MessageSubject.Contains(@">"))
                                    {
                                        MessageSubject.Replace(@">", " ");
                                    }
                                    if (MessageSubject.Contains(@"|"))
                                    {
                                        MessageSubject.Replace(@"|", " ");
                                    }
                                    #endregion

                                    #region Check Mail counter

                                    if (MessageSubject.ToLower().Contains(salesTrendReportPattern))
                                    {
                                        dairy_trend_report_counter = dairy_trend_report_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(productAgeingReportPattern))
                                    {
                                        fresh_dairy_stock_ageing_report_counter = fresh_dairy_stock_ageing_report_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(crateReportBiharPattern))
                                    {
                                        crates_report_bihar_counter = crates_report_bihar_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(crateReportWBPattern))
                                    {
                                        crates_report_wb_counter = crates_report_wb_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(crateReportaasmaPattern))
                                    {
                                        crates_report_aasma_counter = crates_report_aasma_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(crateReportmungerPattern))
                                    {
                                        crates_report_munger_counter = crates_report_munger_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(salesReportSummaryPattern))
                                    {
                                        fresh_dairy_sales_summary_report_counter = fresh_dairy_sales_summary_report_counter + 1;
                                    }
                                    if (MessageSubject.ToLower().Contains(salesReportPattern))
                                    {
                                        fresh_dairy_sales_report_counter = fresh_dairy_sales_report_counter + 1;
                                    }

                                    #endregion
                                    foreach (var attachment in message.Attachments)
                                    {
                                        try
                                        {
                                            LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Found Attachment", "N", "163", null, null, null);
                                            var part1 = (MimePart)attachment;
                                            var fileName = part1.FileName;
                                            FileInfo fi = new FileInfo(fileName);
                                            string extn = fi.Extension.Trim().ToLower();
                                            if (extn.Contains("zip"))
                                            {
                                                LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Found zip Attachment", "N", "170", null, null, null);
                                                if (MessageSubject.ToLower().Contains(salesTrendReportPattern))
                                                {
                                                    dairy_trend_report_counter_zip = dairy_trend_report_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(productAgeingReportPattern))
                                                {
                                                    fresh_dairy_stock_ageing_report_counter_zip = fresh_dairy_stock_ageing_report_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(crateReportBiharPattern))
                                                {
                                                    crates_report_bihar_counter_zip = crates_report_bihar_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(crateReportWBPattern))
                                                {
                                                    crates_report_wb_counter_zip = crates_report_wb_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(crateReportaasmaPattern))
                                                {
                                                    crates_report_aasma_counter_zip = crates_report_aasma_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(crateReportmungerPattern))
                                                {
                                                    crates_report_munger_counter_zip = crates_report_munger_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(salesReportSummaryPattern))
                                                {
                                                    fresh_dairy_sales_summary_report_counter_zip = fresh_dairy_sales_summary_report_counter_zip + 1;
                                                }
                                                if (MessageSubject.ToLower().Contains(salesReportPattern))
                                                {
                                                    fresh_dairy_sales_report_counter_zip = fresh_dairy_sales_report_counter_zip + 1;
                                                }

                                                if (message.Attachments.Count() == 1)
                                                {
                                                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "1 zip Attachment found", "N", "198", null, null, null);

                                                    if (MessageSubject.Length > 230)
                                                    {
                                                        fileName = MessageSubject.Trim().Substring(0, 229);
                                                    }
                                                    else
                                                    {
                                                        fileName = MessageSubject;
                                                    }
                                                    if (!Directory.Exists(attachmentSaveLocation))
                                                    {
                                                        LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Download location folder is missing. Hence created.", "N", "210", null, null, null);

                                                        Directory.CreateDirectory(attachmentSaveLocation);
                                                    }
                                                    fileName = $"{attachmentSaveLocation}{"\\"}{fileName}{extn}";
                                                    try
                                                    {
                                                        if (File.Exists(fileName))
                                                        {
                                                            File.Delete(fileName);
                                                            LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "Duplicate file found hence deleted.", "N", "220", null, null, null);

                                                        }

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "File Operation : Delete due to duplicate", "Y", "227", ex.StackTrace, ex.ToString(), "Moving next");

                                                    }
                                                    using (var stream = File.Create(fileName))
                                                    {
                                                        if (attachment is MessagePart)
                                                        {
                                                            var part = (MessagePart)attachment;

                                                            part.Message.WriteTo(stream);
                                                        }
                                                        else
                                                        {
                                                            var part = (MimePart)attachment;

                                                            part.Content.DecodeTo(stream);
                                                        }
                                                        LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "File Operation : File Download complete", "N", "244", null, null, null);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "File Operation : Download attachment error.", "Y", "251", ex.StackTrace, ex.ToString(), "Moving next");
                                        }
                                    }
                                }
                            }
                            //inbox.AddFlags(uid, MessageFlags.Deleted, false);
                        }
                        catch (ImapCommandException)
                        {
                            inbox.AddFlags(uid, MessageFlags.Deleted, false);
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.ToString());
                            //throw ex;
                        }
                    }


                    //Read Email and save attachment 

                    #region No Email tracker

                    if (dairy_trend_report_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\u2022 "}{" Email not received for Daily Sales Trend Report."}{System.Environment.NewLine}";
                    }
                    if (fresh_dairy_stock_ageing_report_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Fresh Dairy Stock Ageing Report."}{System.Environment.NewLine}";
                    }
                    if (crates_report_bihar_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Crates Report Bihar."}{System.Environment.NewLine}";
                    }
                    if (crates_report_wb_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Crates Report WB."}{System.Environment.NewLine}";
                    }
                    if (crates_report_aasma_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Crates Report Aasma."}{System.Environment.NewLine}";
                    }
                    if (crates_report_munger_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Crates Report Munger."}{System.Environment.NewLine}";
                    }
                    if (fresh_dairy_sales_summary_report_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Fresh Dairy Sales Summary Report."}{System.Environment.NewLine}";
                    }
                    if (fresh_dairy_sales_report_counter < 1)
                    {
                        ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{" Email not received for Fresh Dairy Sales Report."}{System.Environment.NewLine}";
                    }

                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "dairy_trend_report_counter : " + dairy_trend_report_counter, "N", "298", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_stock_ageing_report_counter : " + fresh_dairy_stock_ageing_report_counter, "N", "299", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_bihar_counter : " + crates_report_bihar_counter, "N", "300", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_kolkata_counter : " + crates_report_wb_counter, "N", "301", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_aasma_counter : " + crates_report_aasma_counter, "N", "303", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_munger_counter : " + crates_report_munger_counter, "N", "303", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_sales_summary_report_counter : " + fresh_dairy_sales_summary_report_counter, "N", "302", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_sales_report_counter : " + fresh_dairy_sales_report_counter, "N", "303", null, null, null);


                    #endregion

                    #region No Attachment or Multiple attachment

                    if (dairy_trend_report_counter > 1)
                    {
                        if (dairy_trend_report_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Dairy Trend Report Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (dairy_trend_report_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Dairy Trend Report Email contains multiple zip attachment. Total attachments: "}{dairy_trend_report_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (fresh_dairy_stock_ageing_report_counter > 1)
                    {
                        if (fresh_dairy_stock_ageing_report_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Stock Ageing Report Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (fresh_dairy_stock_ageing_report_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Stock Ageing Report Email contains multiple zip attachment. Total attachments: "}{fresh_dairy_stock_ageing_report_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (crates_report_bihar_counter > 1)
                    {
                        if (crates_report_bihar_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report Bihar Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (crates_report_bihar_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report Bihar Email contains multiple zip attachment. Total attachments: "}{crates_report_bihar_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (crates_report_wb_counter > 1)
                    {
                        if (crates_report_wb_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report WB Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (crates_report_wb_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report WB Email contains multiple zip attachment. Total attachments: "}{crates_report_wb_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (crates_report_aasma_counter > 1)
                    {
                        if (crates_report_aasma_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report Aasma Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (crates_report_aasma_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report Aasma Email contains multiple zip attachment. Total attachments: "}{crates_report_aasma_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (crates_report_munger_counter > 1)
                    {
                        if (crates_report_munger_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report WB Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (crates_report_wb_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Crates Report WB Email contains multiple zip attachment. Total attachments: "}{crates_report_munger_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (fresh_dairy_sales_summary_report_counter > 1)
                    {
                        if (fresh_dairy_sales_summary_report_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Sales Summary Report Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (fresh_dairy_sales_summary_report_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Sales Summary Report Email contains multiple zip attachment. Total attachments: "}{fresh_dairy_sales_summary_report_counter_zip}{System.Environment.NewLine}";
                        }
                    }

                    if (fresh_dairy_sales_report_counter > 1)
                    {
                        if (fresh_dairy_sales_report_counter_zip < 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Sales Report Email does not contain zip attachment."}{System.Environment.NewLine}";
                        }
                        else if (fresh_dairy_sales_report_counter_zip > 1)
                        {
                            ErrorReport = $" {ErrorReport }{ "\t\u2022 "}{"Fresh Dairy Sales Report Email contains multiple zip attachment. Total attachments: "}{fresh_dairy_sales_report_counter_zip}{System.Environment.NewLine}";
                        }
                    }


                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "dairy_trend_report_counter_zip : " + dairy_trend_report_counter_zip, "N", "298", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_stock_ageing_report_counter_zip : " + fresh_dairy_stock_ageing_report_counter_zip, "N", "299", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_bihar_counter_zip : " + crates_report_bihar_counter_zip, "N", "300", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_kolkata_counter_zip : " + crates_report_wb_counter_zip, "N", "301", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_aasma_counter_zip : " + crates_report_aasma_counter_zip, "N", "303", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "crates_report_munger_counter_zip : " + crates_report_munger_counter_zip, "N", "303", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_sales_summary_report_counter_zip : " + fresh_dairy_sales_summary_report_counter_zip, "N", "302", null, null, null);
                    LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "fresh_dairy_sales_report_counter_zip : " + fresh_dairy_sales_report_counter_zip, "N", "303", null, null, null);




                    #endregion


                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                LogHandle.ModuleLogFile("IMAP", "DowloadAttachment", "IMAP Connection error", "Y", "382", ex.StackTrace, ex.ToString(), "Moving next");
            }


            return ErrorReport;
        }
    }
}
