using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace LogToFile
{
    public sealed class LogToFileCreateLog: CodeActivity
    {
        public InArgument<string> Path { get; set; }
        public InArgument<string> Message { get; set; }
        public OutArgument<bool> Flag { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string path = context.GetValue(this.Path);
            string message = context.GetValue(this.Message);
            string error = null;
            try
            {
                LogToFileCore.CreateLog(path, message);
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
