using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelCellIncrementDecrement : CodeActivity
    {
        public InArgument<string> CellAddress { get; set; }
        public InArgument<int> Row { get; set; }
        public InArgument<int> Column { get; set; }
        public OutArgument<string> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string celladdress = context.GetValue(this.CellAddress);
            int row = context.GetValue(this.Row);
            int column = context.GetValue(this.Column);
            string error = null;
            try
            {
                string output = Excel_Core.CellIncrementDecrement(celladdress, row, column);
                context.SetValue(Output,output);
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
