using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsCreateBookMark : CodeActivity
    {
        public InArgument<string> BookMarkName { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string bookmarkname = context.GetValue(this.BookMarkName);
            string error = null;
            try
            {
                WordCoreOperations.WordCreateBookmark(bookmarkname);
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
