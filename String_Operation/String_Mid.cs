using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{

    public sealed class String_Mid : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Text")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Start")]
        [RequiredArgument]
        public InArgument<Int32> Position { get; set; }

        [Category("Input")]
        [DisplayName("Count")]
        [RequiredArgument]
        public InArgument<Int32> Count { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Output String")]
        public OutArgument<string> Output_String { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //try

            //{
                string a = context.GetValue(this.Text);

                int pos= Convert.ToInt32(context.GetValue(this.Position));
                int count = Convert.ToInt32(context.GetValue(this.Count));

                string stringMid = "";

                //if (pos - 1 <= a.Length)
              //  {
                    //if(pos <= 0)
                    //{
                    //    if(count + 1 >= a.Length)
                    //    {
                    //        stringMid = a.Substring(0, a.Length);
                    //    }
                    //    else
                    //    {
                    //        stringMid = a.Substring(0, count);
                    //    }
                    //}
                    //else
                    //{
                         
                        if (count + pos - 1 >= a.Length)
                        {
                            if(pos-1>=a.Length)
                            {
                                stringMid = "";
                            }
                            else stringMid = a.Substring(pos -1, a.Length-pos+1);
                        }
                        else
                        {
                            stringMid = a.Substring(pos - 1, count+1);
                        }
                    //}

                //}
                //else
                //{
                //    stringMid = "";
                //    Result.Set(context, true);
                //}
                    
                
                Output_String.Set(context, stringMid);
                Result.Set(context, true);


                //if (a.Length >= pos-21)
                //{
                //    if(count >0)
                //    {
                //        if (a.Length >= (pos + count))
                //        {
                //            stringMid = a.Substring(pos - 2, count);
                //            //Output_String.Set(context, stringMid);
                //            Result.Set(context, true);
                //        }
                //    }

                //    else
                //    {
                //      //  Output_String.Set(context, "-1");
                //        Result.Set(context, false);
                //    }

                //}
                //else
                //{
                //    Output_String.Set(context, "-1");
                //    Result.Set(context, false);
                //}
            //}
            //catch
            //{
            //    Output_String.Set(context, "-1");
            //    Result.Set(context, false);
            //}
            //stringMid = a.Substring(pos, count);
        }
    }
}
