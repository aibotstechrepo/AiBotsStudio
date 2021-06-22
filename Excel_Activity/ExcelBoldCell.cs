using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelBoldCell : CodeActivity
    {
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }
        public InArgument<bool> Entire_Row { get; set; }
        public InArgument<bool> Entire_Column { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            bool er = context.GetValue(this.Entire_Row);
            bool ec = context.GetValue(this.Entire_Column);
            string error = null;
            try
            {
                Excel_Core.Bold_Cell(from, to, er, ec);
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
