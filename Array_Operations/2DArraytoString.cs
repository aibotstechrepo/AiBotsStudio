using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class _2DArraytoString : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string[][]> ArrayName{ get; set; }
        public OutArgument<string> Data { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            string[][] a = context.GetValue(this.ArrayName);
            string data = "";
            foreach (string[] a1 in a)
            {
                foreach(string a2 in a1)
                {
                    data = data + a2 + " \t";

                }
                data = data+ " \n";
            }
            Data.Set(context, data);
        }
    }
}
