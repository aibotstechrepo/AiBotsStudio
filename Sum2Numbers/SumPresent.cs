using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Sum2Numbers
{
    public sealed class SumPresent : CodeActivity
    {
        public InArgument<int> a { get; set; }
        public InArgument<int> b { get; set; }
        public OutArgument<int> sum { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int num1 = context.GetValue(a);
            int num2 = context.GetValue(b);
            try
            {
                int Sum = Sum2NumCore.Add2Numbers(num1, num2);
                context.SetValue(sum, Sum);
            }
            catch { }
        }
    }
}
