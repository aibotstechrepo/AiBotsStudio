using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Array_Operations
{

    public sealed class Array_Redim : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Array Name")]
        public InOutArgument<string[]> arrName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("New Size")]
        public InArgument<Int32> newSize { get; set; }

        //[Category("Output")]
        //[RequiredArgument]
        //[DisplayName("Resized Array")]
        //public OutArgument<string[]> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] a = context.GetValue(this.arrName);
            int b = context.GetValue(this.newSize);

            if (a != null)
            {
                string dat = a.GetType().Name;
                int counts = dat.Split('[').Length - 1;
                if(counts == 1)
                {
                    
                    
                    Array.Resize(ref a,b);

                    //arrName.Set(context, a);
                    //a.Distinct().ToArray();
                }
            }
            else
            {

            }
            arrName.Set(context, a);
        }
    }
}
