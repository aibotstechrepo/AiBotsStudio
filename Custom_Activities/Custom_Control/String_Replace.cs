using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class String_Replace : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        public InArgument<string> Text_to_Find { get; set; }
        public InArgument<string> Replace_Text { get; set; }
        public OutArgument<string> Result { get; set; }

        string newval;

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            //string text = context.GetValue(this.Text);
            string a = context.GetValue(this.Text);
            string b = context.GetValue(this.Text_to_Find);
            string c = context.GetValue(this.Replace_Text);
            

            if (a.Contains(b))
            {
                //MessageBox.Show("String Found");
                newval = a.Replace(b, c);
                //MessageBox.Show(newval);
            }
            else
            {
                //MessageBox.Show("String not Found");
            }
            Result.Set(context, newval);

        }
    }
}
