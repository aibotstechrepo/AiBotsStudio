using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Array_Operations
{

    public sealed class _2DArrayResize : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Array Name")]
        public InOutArgument<string[][]> ArrayName{ get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("New Row Size")]
        public InArgument<Int32> NewRowSize { get; set; }
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("New Column Size")]
        public InArgument<Int32> NewColumnSize { get; set; }

        //[Category("Output")]
        //[RequiredArgument]
        //[DisplayName("Resized Array")]
        //public OutArgument<string[]> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[][] a = context.GetValue(this.ArrayName);
            int row = context.GetValue(this.NewRowSize);
            int column = context.GetValue(this.NewColumnSize);

            if (a != null)
            {
                Array.Resize(ref a, row);
                Array.Resize(ref a[0], column);
            }
            else
            {

            }
            ArrayName.Set(context, a);
        }
    
    }
}
