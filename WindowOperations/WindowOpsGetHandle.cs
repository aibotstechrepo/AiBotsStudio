using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WindowOperations
{
    public sealed class WindowOpsGetHandle : CodeActivity
    {
        public InArgument<string> Title { get; set; }
        public OutArgument<IntPtr> Handle { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string title = context.GetValue(this.Title);
            string error = null;
            try
            {
                IntPtr handle = WindowOpsCore.GetHandle(title);
                context.SetValue(Handle, handle);
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
