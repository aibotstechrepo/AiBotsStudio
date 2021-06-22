using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace LogHandler
{
    public static class LogHandle
    {
        private static string LogSaveLocation = ConfigurationManager.AppSettings["LogSaveLocation"].ToString().Trim();

        public static void ModuleLogFile(string ClassName, string FunctionName, string Report, string ExceptionStatus, string LineNumber, string StackTract, string ExceptionMessage, string Status)
        {
            //Date,class,function,report,exception Y/N,line number, StackTrace, exception message,OuputStatus
            string LOG = $"{DateTime.Now} { "," }{ClassName}{","}{FunctionName}{","}{Report}{","}{ExceptionStatus }{","}{LineNumber}{","}{StackTract }{","}{ExceptionMessage}{","}{Status}";
            //StreamWriter log;
            string LogFile = $"{LogSaveLocation}{"\\"}{"Module.log"}";
            if (!Directory.Exists(LogSaveLocation))
                Directory.CreateDirectory(LogSaveLocation);
            using (StreamWriter sw = (File.Exists(LogFile)) ? File.AppendText(LogFile) : File.CreateText(LogFile))
            {
                sw.WriteLine(LOG);
                sw.Close();

            }
        }

        public static void MessageBodyData(string Data)
        {
            string Values = Data;
            //StreamWriter log;
            string DataFile = $"{LogSaveLocation}{"\\"}{"Values.txt"}";
            if (!Directory.Exists(LogSaveLocation))
                Directory.CreateDirectory(LogSaveLocation);
            using (StreamWriter sw = (File.Exists(DataFile)) ? File.AppendText(DataFile) : File.CreateText(DataFile))
            {
                sw.WriteLine(Values);
                sw.Close();
            }
        }

        public static void MessageBodyDataClear()
        {
            //string Values = Data;
            //StreamWriter log;
            string DataFile = $"{LogSaveLocation}{"\\"}{"Values.txt"}";
            if (!Directory.Exists(LogSaveLocation))
                Directory.CreateDirectory(LogSaveLocation);
            using (StreamWriter sw = (File.Exists(DataFile)) ? File.CreateText(DataFile) : File.CreateText(DataFile))
            {
                //sw.WriteLine(Values);
                sw.Close();
            }
        }

        public static void ErrorReportinFile(string Data)
        {
            string Values = Data;
            //StreamWriter log;
            string DataFile = $"{LogSaveLocation}{"\\"}{"Error.txt"}";
            if (!Directory.Exists(LogSaveLocation))
                Directory.CreateDirectory(LogSaveLocation);
            using (StreamWriter sw = (File.Exists(DataFile)) ? File.AppendText(DataFile) : File.CreateText(DataFile))
            {
                sw.WriteLine(Values);
                sw.Close();
            }

        }

        public static void ErrorReportinFileClear()
        {

            string DataFile = $"{LogSaveLocation}{"\\"}{"Error.txt"}";
            if (!Directory.Exists(LogSaveLocation))
                Directory.CreateDirectory(LogSaveLocation);
            using (StreamWriter sw = (File.Exists(DataFile)) ? File.CreateText(DataFile) : File.CreateText(DataFile))
            {
                // sw.WriteLine(Values);
                sw.Close();
            }

        }

        public static void KillSpecificExcelFileProcess(string excelFileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                int processe = processes.Count();
                if (process.MainWindowTitle.Contains(excelFileName))
                    process.Kill();
            }
        }
    }
}
