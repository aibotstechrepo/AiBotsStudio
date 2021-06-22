using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsExportToPDF : CodeActivity
    {
        public InArgument<string> PDFPath { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string pdfpath = context.GetValue(this.PDFPath);
            string error = null;
            try
            {
                WordCoreOperations.WordExportToPDF(pdfpath);
                context.SetValue(Error, error);
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
