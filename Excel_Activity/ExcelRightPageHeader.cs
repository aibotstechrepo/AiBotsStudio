using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelRightPageHeader : CodeActivity
    {
        public InArgument<string> HeaderName { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string headername = context.GetValue(this.HeaderName);
            string error = null;
            try
            {
                Excel_Core.RightPageHeader(headername);
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
