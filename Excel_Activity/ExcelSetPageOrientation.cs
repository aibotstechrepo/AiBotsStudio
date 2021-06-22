using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelSetPageOrientation : CodeActivity
    {
        public InArgument<bool> Orientation { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            bool orientation = context.GetValue(this.Orientation);
            string error = null;
            try
            {
                Excel_Core.SetPageOrientation(orientation);
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
