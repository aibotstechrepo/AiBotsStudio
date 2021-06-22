using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsSetBookMarkContent : CodeActivity
    {
        public InArgument<string> BookMarkName { get; set; }
        public InArgument<string> Text { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string bookmarkname = context.GetValue(this.BookMarkName);
            string text = context.GetValue(this.Text);
            string error = null;
            try
            {
                WordCoreOperations.WordSetBookMarkContent(bookmarkname, text);
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
