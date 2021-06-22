using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Array_Operations
{

    public sealed class Array_Concat : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Primary Array")]
        public InOutArgument<string[]> PrimaryArray { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Secondary Array")]
        public InArgument<string[]> SecondaryArray { get; set; }

        //[Category("Output")]
        //[RequiredArgument]
        //[DisplayName("Resized Array")]
        //public OutArgument<dynamic> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] a = context.GetValue(this.PrimaryArray);
            string[] b = context.GetValue(this.SecondaryArray);


            if (a != null)
            {
                string dat = a.GetType().Name;
                int counts = dat.Split('[').Length - 1;
                if (counts == 1)
                {
                    int i = a.Length;
                    foreach(string arr in b)
                    {
                        Array.Resize(ref a, i + 1);
                        a[i] = arr;
                        i++;
                    }

                    
                }
            }
            else
            {

            }
            PrimaryArray.Set(context, a);
        }
    }
}
