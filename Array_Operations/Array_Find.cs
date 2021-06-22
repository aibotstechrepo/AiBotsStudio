using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel; 
 

namespace Array_Operations
{

    public sealed class Array_Find : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Case Sensitive")]
        public Boolean Case { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Array Name")]
        public InArgument<string[]> ArrayName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Data to find")]
        public InArgument<string> Key { get; set; }

        [Category("Output")]
        [RequiredArgument]
        [DisplayName("Index of data")]
        public OutArgument<int[]> outarr { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] a = context.GetValue(this.ArrayName);
            string b =  context.GetValue(this.Key);
            int[] outdata = new int[0];
            int j = 0;
            if (a != null)
            {
                string dat = a.GetType().Name;
                int counts = dat.Split('[').Length - 1;
                if (counts == 1)
                {
                    for(int i = 0; i<a.Length; i++)
                    {
                        if (Case == true)
                        {
                            int a1 = string.Compare(a[i], b, false);
                            if (a1 == 0)
                            {
                                Array.Resize(ref outdata, outdata.Length + 1);
                                outdata[j] = i;
                                j++;
                                //outarr.Set(context, i);
                                //break;
                            }

                        }
                        if (Case == false)
                        {
                            int a1 = string.Compare(a[i], b, true);
                            if (a1 == 0)
                            {
                                Array.Resize(ref outdata, outdata.Length + 1);
                                outdata[j] = i;
                                j++;
                                //outarr.Set(context, i);
                                //break;
                            }
                        }

                        //outarr.Set(context, -1);
                    }   
                        
                    ////// determine type here
                    ////var type = a.GetType();

                    ////// create an object of the type
                    ////var obj = (int)Activator.CreateInstance(type);

                    //////dynamic[] asd = a;

                    ////Array.Copy(b, a, b.length);
                    ////Type t = a.GetType();
                    ////object y = Array.CreateInstance(,);
                    //int aa = Array.IndexOf(a, b,);
                    //a.Contains("str", StringComparer.CurrentCultureIgnoreCase);
                    ////a = asd;
                    //outarr.Set(context, aa);
                    //a.Distinct().ToArray();
                }
            }
            else
            {

            }
            outarr.Set(context, outdata);
        }
    }
}
