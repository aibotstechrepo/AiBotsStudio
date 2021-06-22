using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsClose : CodeActivity
    {
        public InArgument<bool> CloseSave { get; set; }
        public InArgument<bool> QuitSave { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            bool closesave = context.GetValue(this.CloseSave);
            bool quitsave = context.GetValue(this.QuitSave);
            string error = null;
            try
            {
                WordCoreOperations.WordClose(closesave, quitsave);
                context.SetValue(Error, error);
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
