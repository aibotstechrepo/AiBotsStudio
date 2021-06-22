using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace LogHandler
{
    public sealed class LogHandlerKillExcelFileProcess : CodeActivity
    {
        public InArgument<string> ExcelFileName { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string filename = context.GetValue(this.ExcelFileName);
            string error = null;
            try
            {
                LogHandle.KillSpecificExcelFileProcess(filename);
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
