using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{
    public sealed class Excel_Scope : CodeActivity
    {
        CustomFunction c = new CustomFunction();
        // Define an activity input argument of type string
        public InArgument<string> File_Name { get; set; }
        public InArgument<string> Output_Excel_Path { get; set; }
        public InArgument<string> Output_Excel_Name { get; set; }
        //public OutArgument<string> Result { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            //// Obtain the runtime value of the Text input argument
            string file = context.GetValue(this.File_Name);
            string EFilePath = context.GetValue(this.Output_Excel_Path);
            string EFileName = context.GetValue(this.Output_Excel_Name);
            //string data = c.PheniexOCR(file);
            //Result.Set(context, data);
            
            c.Invoice(file, EFilePath, EFileName);
        }

        //public InArgument<string> File_Name { get; set; }
        //public OutArgument<string> data { get; set; }

        //protected override void Execute(CodeActivityContext context)
        //{
        //    string file = context.GetValue(this.File_Name);
        //    c.datapush(file);
        //    data.Set(context,c.dataread());

        //}
    }
}
