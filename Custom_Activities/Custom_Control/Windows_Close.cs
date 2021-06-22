using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{
    public sealed class Windows_Close : CodeActivity
    {
        public InArgument<string> Windows_Title { get; set; }
        CustomFunction cf = new CustomFunction();
        protected override void Execute(CodeActivityContext context)
        {
            string text = context.GetValue(this.Windows_Title);
            cf.Close_Window(text);
        }
    }
}
