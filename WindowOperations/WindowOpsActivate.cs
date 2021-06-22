using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WindowOperations
{
    public sealed class WindowOpsActivate : CodeActivity
    {
        public InArgument<string> Title { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string title = context.GetValue(this.Title);
            string error = null;
            try
            {
                WindowOpsCore.WindowActivate(title);
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
