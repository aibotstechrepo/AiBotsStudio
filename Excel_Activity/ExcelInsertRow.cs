using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelInsertRow : CodeActivity
    {
        public InArgument<int> RowNumber { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int rownumber = context.GetValue(this.RowNumber);
            string error = null;
            try
            {
                Excel_Core.InsertRow(rownumber);
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
