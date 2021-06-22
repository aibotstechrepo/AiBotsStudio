using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace LogToFile
{
    public sealed class Add2Num : CodeActivity
    {
        public InArgument<int> Num1 { get; set; }
        public InArgument<int> Num2 { get; set; }
        public OutArgument<int> Sum { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int num1 = context.GetValue(this.Num1);
            int num2 = context.GetValue(this.Num2);
            try
            {
                int sum = LogToFileCore.Add2Numbers(num1, num2);
                context.SetValue(Sum, sum);
            }
            catch { }
        }
    }
}
