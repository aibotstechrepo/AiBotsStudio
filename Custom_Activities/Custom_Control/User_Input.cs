using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class User_Input : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Input_Filed { get; set; }
        public InArgument<string> Value { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            //string text = context.GetValue(this.Text);
        }
    }
}
