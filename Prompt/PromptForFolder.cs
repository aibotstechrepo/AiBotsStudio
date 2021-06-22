using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Prompt
{
    public sealed class PromptForFolder : CodeActivity
    {
        public OutArgument<string> FolderPath { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string error = null;
            try
            {
                string folderpath = PromptCore.PromptSelectFolder();
                context.SetValue(FolderPath, folderpath);
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
