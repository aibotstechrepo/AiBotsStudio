using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace LogHandler
{
    public sealed class LogHandlerModule : CodeActivity
    {
        public InArgument<string> ClassName { get; set; }
        public InArgument<string> FunctionName { get; set; }
        public InArgument<string> Report { get; set; }
        public InArgument<string> ExceptionStatus { get; set; }
        public InArgument<string> LineNumber { get; set; }
        public InArgument<string> StackTract { get; set; }
        public InArgument<string> ExceptionMessage { get; set; }
        public InArgument<string> Status { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string classname = context.GetValue(this.ClassName);
            string functionname = context.GetValue(this.FunctionName);
            string report = context.GetValue(this.Report);
            string exceptionstatus = context.GetValue(this.ExceptionStatus);
            string linenumber = context.GetValue(this.LineNumber);
            string stacktract = context.GetValue(this.StackTract);
            string exceptionmessage = context.GetValue(this.ExceptionMessage);
            string status = context.GetValue(this.Status);
            string error = null;
            try
            {
                LogHandle.ModuleLogFile(classname, functionname, report, exceptionstatus, linenumber, stacktract, exceptionmessage, status);
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
