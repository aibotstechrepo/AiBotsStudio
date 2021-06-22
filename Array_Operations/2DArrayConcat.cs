using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class _2DArrayConcat : CodeActivity
    {
         
        public InOutArgument<string[][]> PrimaryArray { get; set; }
        public InArgument<string[][]> SecondaryArray { get; set; }
         
        protected override void Execute(CodeActivityContext context)
        {
             
            string[][] array1 = context.GetValue(this.PrimaryArray);
            string[][] array2 = context.GetValue(this.SecondaryArray);
            int len = array2.Length;
            string[][] result = new string[array1.Length + array2.Length][];

            array1.CopyTo(result, 0);
            array2.CopyTo(result, array1.Length);
            PrimaryArray.Set(context, result);
        }
    }
}
