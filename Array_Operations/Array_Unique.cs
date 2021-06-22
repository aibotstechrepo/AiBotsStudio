using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Array_Operations
{

    public sealed class Array_Unique : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Array Name")]
        public InOutArgument<string[]> arrName { get; set; }

        //[Category("Output")]
        //[RequiredArgument]
        //[DisplayName("Resized Array")]
        //public OutArgument<object> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] a = context.GetValue(this.arrName);
           // int b = context.GetValue(this.newSize);

            if (a != null)
            {
                string dat = a.GetType().Name;
                int counts = dat.Split('[').Length - 1;
                if (counts == 1)
                {

                    string[] asd = a.Distinct().ToArray();

                    //Array.Copy(b, a, b.length);

                    //Array.Resize(ref asd, b);
                    //a = asd;
                    arrName.Set(context, asd);
                    //a.Distinct().ToArray();
                }
            }
            else
            {

            }
        }
    }
}
