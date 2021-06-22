using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelLastRowByCellAddress : CodeActivity
    {
        public InArgument<string> CellAddress { get; set; }
        public OutArgument<string> RowAddress { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string celladdress = context.GetValue(this.CellAddress);
            string error = null;
            try
            {
                string rowaddress = Excel_Core.GetLastRowByCellAddress(celladdress);
                context.SetValue(RowAddress, rowaddress);
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
