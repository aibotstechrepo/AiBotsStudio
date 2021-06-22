using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace String_Operation
{
    public sealed class String_Extract_Characaters : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Data { get; set; }

        [Category("Output")]
        [DisplayName("Number")]
        public OutArgument<string> Characters { get; set; }

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
                    string characters = new String(data.Where(c => Char.IsLetter(c)).ToArray());
                    context.SetValue(Characters, characters);
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
