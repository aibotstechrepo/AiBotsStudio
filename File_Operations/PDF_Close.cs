using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Diagnostics;
using System.ComponentModel;

namespace File_Operations
{

    public sealed class PDF_Close : CodeActivity
    {
        // public InArgument<string> PDF { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //string text = context.GetValue(this.Text);
            try
            {
                bool a = false;
                a = FindAndKillProcess("AcroRd32");
                if (a == true)
                {
                    Result.Set(context, true);
                }
                else
                {
                    Result.Set(context, false);
                }
            }
            catch
            {
                Result.Set(context, false);
            }
            
        }

        public bool FindAndKillProcess(string name)
        { 
            foreach (Process clsProcess in Process.GetProcesses())
            { 
                if (clsProcess.ProcessName.StartsWith(name)) 
                { 
                    clsProcess.Kill();
                  // System.Windows.MessageBox.Show("killed");
                    return true;
                }
            } 
            return false;
        }
        #region close file by title
        //public void FindAndKilloneProcess(string name)
        //{

        //    Process[] processlist = Process.GetProcesses();

        //    foreach (Process process in processlist)
        //    {
        //        if (!String.IsNullOrEmpty(process.MainWindowTitle))
        //        {
        //            if (process.MainWindowTitle == textBox1.Text)
        //            {
        //                int pid = process.Id;
        //                if (process.Id == pid)
        //                {

        //                    process.Kill();
        //                    break;
        //                }
        //            }
        //            //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
        //        }
        //    }
        //}
        #endregion
    }
}
