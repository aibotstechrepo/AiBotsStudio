using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class Loop_ForEach : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Int32> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            // Obtain the runtime value of the Text input argument
            // Obtain the runtime value of the Text input argument
            Int32 text = context.GetValue(this.Text);
        }
    }
}
