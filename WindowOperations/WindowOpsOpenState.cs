using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WindowOperations
{
    public sealed class WindowOpsOpenState: CodeActivity
    {
        public InArgument<string> Title { get; set; }
        public InArgument<int> State { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string title = context.GetValue(this.Title);
            int state = context.GetValue(this.State);
            string error = null;
            try
            {
                WindowOpsCore.WindowOpen(title,state);
            }
            catch(Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }
        }

    }
}
