using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace File_Operations
{
    public sealed class MakeZipOperation : CodeActivity
    {
        public InArgument<string> ZipFileLocation { get; set; }
        public InArgument<string> ExtractedFileLocation { get; set; }
        public OutArgument<string> Result { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string zipfilelocation = context.GetValue(this.ZipFileLocation);
            string extractedfilelocation = context.GetValue(this.ExtractedFileLocation);
            string error = null;
            try
            {
                string result = ZipOperation.ExtractZipFiles(zipfilelocation, extractedfilelocation);
                context.SetValue(Result, result);
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
