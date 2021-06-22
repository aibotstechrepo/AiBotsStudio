using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class ArrayToString : CodeActivity
    {
         
        public InArgument<string[]> ArrayName { get; set; }
        public OutArgument<string> Data { get; set; }
         
        protected override void Execute(CodeActivityContext context)
        {
            string[] arrayName = context.GetValue(this.ArrayName);
            string data = "";
            foreach(string a in arrayName)
            {
                data = data + a;
            }
            Data.Set(context, data);
        }
    }
}
