using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WindowOperations
{
    public sealed class WindowOpsExists : CodeActivity
    {
        public InArgument<string> Title { get; set; }
        public OutArgument<bool> Exists { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string title = context.GetValue(this.Title);
            string error = null;
            try
            {
                bool exists = WindowOpsCore.WinExists(title);
                context.SetValue(Exists, exists);
                context.SetValue(Error, error);
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
