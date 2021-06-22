using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace String_Operation
{
    public sealed class String_Extract_Numbers : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Data { get; set; }

        [Category("Output")]
        [DisplayName("Number")]
        public OutArgument<int> Number { get; set; }

        [Category("Output")]
        [DisplayName("Error")]
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string data = context.GetValue(this.Data);
            string error = null;
            try
            {

                if (!string.IsNullOrWhiteSpace(data))
                {
                    string numeric = new String(data.Where(Char.IsDigit).ToArray());
                    context.SetValue(Number, numeric);
                }
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
