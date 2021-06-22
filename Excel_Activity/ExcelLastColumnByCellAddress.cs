using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelLastColumnByCellAddress : CodeActivity
    {
        public InArgument<string> CellAddress { get; set; }
        public OutArgument<string> ColumnAddress { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string celladdress = context.GetValue(this.CellAddress);
            string error = null;
            try
            {
                string columnaddress = Excel_Core.GetLastColumnByCellAddress(celladdress);
                context.SetValue(ColumnAddress,columnaddress);
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
