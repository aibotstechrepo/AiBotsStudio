using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace String_Operation
{ 
    public sealed class String_Trim_Char : CodeActivity
    {
        public enum oper
        {
            Right,
            Left
        }
        //public enum oper1
        //{
        //    Replace_Original,
        //    New_Copy
        //}

        [Category("Input")]
        [DisplayName("String to trim")]
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("No. Of Characters")]
        [RequiredArgument]
        public InArgument<Int32> size { get; set; }

        [Category("Input")]
        [DisplayName("Direction")]
        public oper op { get; set; }

        //[Category("Input")]
        //[DisplayName("Out Type")]
        //public oper1 op1 { get; set; }

        [Category("Output")]
        [DisplayName("Output String")]
        public OutArgument<string> Output_String { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string text = context.GetValue(this.Text);
                int siz = context.GetValue(this.size);
                int oval = Convert.ToInt32(op);
                //int oval1 = Convert.ToInt32(op1);
                string outVal = "";

                 
                //if (oval == 0 && oval1 == 0) //trim right and replace
                //{
                //    outVal = text.Substring(0, siz-1);
                //    Text.Set(context, outVal);
                //}
                //else if (oval == 0 && oval1 == 1) //trim right and new
                //{
                //    outVal = text.Substring(0, siz - 1);
                //    Output_String.Set(context, outVal);
                //}
                //else if (oval == 1 && oval1 == 0) //trim Left and replace
                //{
                //    outVal = text.Substring(siz - 1, text.Length -1);
                //    Text.Set(context, outVal);
                //}
                //else if (oval == 1 && oval1 == 1) //trim Left and new
                //{
                //    outVal = text.Substring(siz - 1, text.Length - 1);
                //    Output_String.Set(context, outVal);
                //}
                //else
                //{

                //}
                if(text.Length < siz )
                {
                    Output_String.Set(context, "");
                }                
                else if (oval == 0) //trim right and new
                {
                    outVal = text.Substring(0, text.Length - siz);
                    Output_String.Set(context, outVal);
                } 
                else if (oval == 1) //trim Left and new
                { 
                    outVal = text.Substring(siz, text.Length - siz); 
                    Output_String.Set(context, outVal);
                } 
            //}
            //catch
            //{
            //    ;
            //}
        }
    }
}
