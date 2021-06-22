using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Excel_Activity
{
    public sealed class ExcelWrapText : CodeActivity
    {
        public enum sheet
        {
            True,
            False
        }

        [Category("Input")]
        [DisplayName("Entire Sheet")]
        [DefaultValue("False")]
        public sheet sh { get; set; }

        [Category("Input")]
        [DisplayName("Entire Row")]
        [DefaultValue("False")]
        public sheet ro { get; set; }

        [Category("Input")]
        [DisplayName("Entire Column")]
        [DefaultValue("False")]
        public sheet col { get; set; }

        [Category("Input")]
        [DisplayName("Enable")]
        [DefaultValue("True")]
        public sheet en { get; set; }
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }

        [Category("Output")]
        [DisplayName("Data")]
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            string error = null;
            try
            {
                bool sheet = Convert.ToBoolean(sh);
                bool row = Convert.ToBoolean(ro);
                bool column = Convert.ToBoolean(col);
                bool enable = Convert.ToBoolean(en);
                Excel_Core.WrapText(from, to, row, column, sheet, enable);
            }
            catch(Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }

        }
    }
}
