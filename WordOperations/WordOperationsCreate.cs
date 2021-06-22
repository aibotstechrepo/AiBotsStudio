using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using Word = Microsoft.Office.Interop.Word;

namespace WordOperations
{
    public sealed class WordOperationsCreate: CodeActivity
    {
        public OutArgument<object> Output { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string error = null;

            try
            {
                object output = WordCoreOperations.WordCreate();
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
