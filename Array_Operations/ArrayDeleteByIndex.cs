using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class ArrayDeleteByIndex : CodeActivity
    {
        // Define an activity input argument of type string
        public InOutArgument<string[]> ArrayName { get; set; }
        public InArgument<int> Index { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            string[] arrayName = context.GetValue(ArrayName);
            int index = context.GetValue(Index);
             
                try
                {

                    string data = arrayName[index];
                    arrayName = arrayName.Where(val => val != data).ToArray();
                    ArrayName.Set(context, arrayName);
                }
                catch
                {
                    ArrayName.Set(context, arrayName);
                }

             
        }
    }
}
