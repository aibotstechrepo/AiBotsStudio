using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelSetRowHeight : CodeActivity
    {
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }
        public InArgument<double> Height { get; set; }
        public InArgument<bool> Entire_Column { get; set; }
        public InArgument<bool> Entire_Sheet { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            double height = context.GetValue(this.Height);
            bool ec = context.GetValue(this.Entire_Column);
            bool es = context.GetValue(this.Entire_Sheet);
            string error = null;
            try
            {
                Excel_Core.SetRowHeight(from, to, height, ec, es);
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
