using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WindowOperations
{
    public sealed class WindowOpsElement : CodeActivity
    {
        public InArgument<string> Title { get; set; }
        public InArgument<string> Classname { get; set; }
        public InArgument<int> Instance { get; set; }
        public InArgument<string> Operation { get; set; }
        public InArgument<string> Text { get; set; }
        public OutArgument<string> Error { get; set; }
        public OutArgument<object> Output { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string title = context.GetValue(this.Title);
            string classname = context.GetValue(this.Classname);
            int instance = context.GetValue(this.Instance);
            string operation = context.GetValue(this.Operation);
            string text = context.GetValue(this.Text);
            string error = null;
            try
            {
                object output = WindowOpsCore.WinElement(title,classname,instance,operation,text);
                context.SetValue(Output, output);
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
