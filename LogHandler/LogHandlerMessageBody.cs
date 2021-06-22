using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace LogHandler
{
    public sealed class LogHandlerMessageBody : CodeActivity
    {
        public InArgument<string> Data { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string data = context.GetValue(this.Data);
            string error = null;
            try
            {
                LogHandle.MessageBodyData(data);
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
