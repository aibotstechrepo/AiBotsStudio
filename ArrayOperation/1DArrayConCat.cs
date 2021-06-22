using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace ArrayOperation
{

    public sealed class _1DArrayConCat : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string[]> Array1 { get; set; }
        public InArgument<string[]> Array2 { get; set; }
        public OutArgument<string[]> Output { get; set; }
        public OutArgument<string> Error { get; set; }
         
        protected override void Execute(CodeActivityContext context)
        { 
            string[] array1 = context.GetValue(this.Array1);
            string[] array2 = context.GetValue(this.Array2);
            string error = null;

            try
            {
                string[] output = ArrayCoreOperation.ArrayConCatinationSingleDimention(array1, array2);

                context.SetValue(Output, output);
                context.SetValue(Error, error);
            }
            catch(Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Output, errorArray);
                context.SetValue(Error, error);
            }

        }
    }
}
