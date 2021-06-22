using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelColumnNumber : CodeActivity
    {
        public InArgument<string> ColumnAddress { get; set; }
        public OutArgument<int> ColumnNumber { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string columnaddress = context.GetValue(this.ColumnAddress);
            string error = null;
            try
            {
                int columnnumber = Excel_Core.ColumnNumber(columnaddress);
                context.SetValue(ColumnNumber, columnnumber);
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
