using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelHideWorksheet : CodeActivity
    {
        public InArgument<int> SheetNumber { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int sheetnumber = context.GetValue(this.SheetNumber);
            string error = null;
            try
            {
                Excel_Core.HideWorksheet(sheetnumber);
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
