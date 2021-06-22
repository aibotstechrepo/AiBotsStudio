using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class ArrayTranspose : CodeActivity
    {
        
        public InArgument<string[]> ArrayName { get; set; }
        public OutArgument<string[][]> TransposedArray { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string[] arr = context.GetValue(this.ArrayName);
            string[][] data = new string[1][];
            string a =data.Length.ToString();
            data[0] = new string[arr.Length];
            for(int i=0;i<arr.Length;i++)
            {
                data[0][i] = arr[i];
            }
            TransposedArray.Set(context, data);
        }
    }
}
