using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Excel_Activity
{
    public sealed class ExcelSetPageSize : CodeActivity
    {
        public InArgument<XlPaperSize> PaperSize { get; set; }
        public OutArgument<bool> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            XlPaperSize papersize = context.GetValue(this.PaperSize);
            string error = null;
            try
            {
                bool output = Excel_Core.SetPageSize(papersize);
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
