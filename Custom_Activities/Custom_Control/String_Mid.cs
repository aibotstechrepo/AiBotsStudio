using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class String_Mid : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        public InArgument<int> Position { get; set; }
        public InArgument<int> Count { get; set; }
        public OutArgument<string> Result { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);


            string a = context.GetValue(this.Text);

            int pos = Convert.ToInt32(context.GetValue(this.Position));
            int count = Convert.ToInt32(context.GetValue(this.Count));

            string stringMid = a.Substring(pos, count);
            //MessageBox.Show(stringMid);
            Result.Set(context, stringMid);
        }
    }
}
