using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Runtime.Remoting.Contexts;

namespace EnvironmentFunctions
{
    public sealed class GetPassword : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Password")]
        public InArgument<string> Password { get; set; }
        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<string> Result { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string result = context.GetValue(this.Password);
            context.SetValue(Result, result);
        }
    }
}