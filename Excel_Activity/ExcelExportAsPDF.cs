using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelExportAsPDF : CodeActivity
    {
        public InArgument<string> ExportPath { get; set; }
        public InArgument<string> FileName { get; set; }
        public InArgument<string> Range { get; set; }
        public OutArgument<bool> Output { get; set; }
        public OutArgument<bool> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string exportpath = context.GetValue(this.ExportPath);
            string filename = context.GetValue(this.FileName);
            string range = context.GetValue(this.Range);
            string error = null;
            try
            {
                bool output = Excel_Core.ExportAsPDF(exportpath, filename, range);
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
