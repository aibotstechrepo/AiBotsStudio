﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace IE
{

    public sealed class Chrome_Navigate : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> URL { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string url = context.GetValue(this.URL);
            CoreFunction.ChromeNavigate(url);
        }
    }
}
