using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Array_Operations
{

    public sealed class Array_Trim : CodeActivity
    {
        public enum oper
        {
            Right,
            Left
        }

        [Category("Input")]
        [DisplayName("Direction")]
        public oper TrimDirection { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Array")]
        public InOutArgument<string[]> arrName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("No. of Characters to Trim")]
        public InArgument<Int32> newSize { get; set; }

        //[Category("Output")]
        //[RequiredArgument]
        //[DisplayName("Trimed Array")]
        //public OutArgument<string[]> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] a = context.GetValue(this.arrName);
            int b = context.GetValue(this.newSize);
            int oval = Convert.ToInt32(TrimDirection);
            if (a != null)
            {
                string dat = a.GetType().Name;
                int counts = dat.Split('[').Length - 1;
                if (counts == 1)
                {
                    for(int i=0; i<a.Length; i++)
                    {

                        if (a[i].Length < b)
                        {
                            a[i] = "";
                        }
                        else if (oval == 0) //trim right and new
                        {
                            a[i] = a[i].Substring(0, a[i].Length - b); 
                        }
                        else if (oval == 1) //trim Left and new
                        {
                            a[i] = a[i].Substring(b, a[i].Length - b);
                        } 
                    }
                   

                    arrName.Set(context, a);

                }
            }
            else
            {

            }
        }

    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
