using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsFindAndReplace : CodeActivity
    {
        public InArgument<string> Find { get; set; }
        public InArgument<string> Replace { get; set; }
        public InArgument<int> Type { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string find = context.GetValue(this.Find);
            string replace = context.GetValue(this.Replace);
            int type = context.GetValue(this.Type);
            string error = null;
            try
            {
                WordCoreOperations.WordFindandReplace(find, replace, type);
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
