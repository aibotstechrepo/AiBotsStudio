using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Array_Operations
{

    public sealed class ArrayDisplay : CodeActivity
    {
        
        public InArgument<string[]> ArrayName{ get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
             
            string[] text = context.GetValue(this.ArrayName);
            string a = "";
            foreach(string b in text)
            {
                a = a + b + "\n";
            }
            System.Windows.MessageBox.Show(a, "1D Array Display", System.Windows.MessageBoxButton.OK);
        }
    }
}
