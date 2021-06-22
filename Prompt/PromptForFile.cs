using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Prompt
{
    public sealed class PromptForFile : CodeActivity
    {
        public OutArgument<string> FilePath { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string error = null;
            try
            {
                string filepath = PromptCore.PromptSelectFile();
                context.SetValue(FilePath, filepath);
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
