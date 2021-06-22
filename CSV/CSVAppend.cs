using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CSV
{
    public sealed class CSVAppend : CodeActivity
    {
        [Category("Input")]
        [DisplayName("FileName")]
        public InArgument<string> FilePath { get; set; }
        [Category("Input")]
        [DisplayName("Text")]
        [Description("Separate with delimitter")]
        public InArgument<List<string>> Text { get; set; }
        [Category("Output")]
        [DisplayName("Error")]
        public InArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string filepath = context.GetValue(this.FilePath);
            List<string> text = context.GetValue(this.Text);
            string error = null;
            try
            {
                CSVCore.AppendCSV(filepath, text);
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
