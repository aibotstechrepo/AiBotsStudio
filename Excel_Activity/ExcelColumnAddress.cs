using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelColumnAddress : CodeActivity
    {
        public InArgument<int> ColumnNumber { get; set; }
        public OutArgument<string> ColumnAddress { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int columnnumber = context.GetValue(this.ColumnNumber);
            string error = null;
            try
            {
                string columnaddress = Excel_Core.ColumnAdress(columnnumber);
                context.SetValue(ColumnAddress, columnaddress);
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
