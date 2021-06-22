using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelPageBreak : CodeActivity
    {
        public OutArgument<int[]> PageBreak { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string error = null;
            try
            {
                int[] pagebreak = Excel_Core.PageBreak();
                context.SetValue(PageBreak, pagebreak);
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
