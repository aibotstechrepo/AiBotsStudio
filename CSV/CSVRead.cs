using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSV
{
    public sealed class CSVRead : CodeActivity
    {
        [Category("Input")]
        [DisplayName("FileName")]
        public InArgument<string> FilePath { get; set; }
        [Category("Input")]
        [DisplayName("Column Number")]
        public InArgument<int> ColumnNumber { get; set; }
        [Category("Input")]
        [DisplayName("Include Header")]
        public InArgument<bool> IncludeHeader { get; set; }
        [Category("Input")]
        [DisplayName("Delimiter")]
        public InArgument<char> Delimiter { get; set; }
        [Category("Output")]
        [DisplayName("List")]
        public OutArgument<List<string>> Output { get; set; }
        [Category("Output")]
        [DisplayName("Error")]
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string filepath = context.GetValue(this.FilePath);
            int columnnumber = context.GetValue(this.ColumnNumber);
            bool header = context.GetValue(this.IncludeHeader);
            char delimiter = context.GetValue(this.Delimiter);
            string error = null;
            try
            {
                List<string> output = CSVCore.ReadCSV(filepath, columnnumber, header, delimiter);
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
