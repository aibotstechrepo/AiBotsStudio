using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class String_Match : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        public InArgument<string> Sub_String { get; set; }
        public OutArgument<bool> Result { get; set; }

        bool res = false;
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            
            string a = context.GetValue(this.Text);
            string b = context.GetValue(this.Sub_String);
            if (a.Contains(b))
            {
                //MessageBox.Show("String Found");
                res = true;
            }
            else
            {
                //MessageBox.Show("String not Found");
                res = false;
            }

            Result.Set(context, res);
        }
    }
}
