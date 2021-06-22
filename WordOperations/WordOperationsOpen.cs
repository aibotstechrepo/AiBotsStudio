using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsOpen : CodeActivity
    {
        public InArgument<object> FilePath { get; set; }
        public OutArgument<object> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            object filePath = context.GetValue(this.FilePath);
            string error = null;

            try
            {
                object output = WordCoreOperations.WordOpen(filePath);
                context.SetValue(Output, output);
                context.SetValue(Error, error);
            }
            catch (Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Output, errorArray);
                context.SetValue(Error, error);
            }
        }
    }
}
