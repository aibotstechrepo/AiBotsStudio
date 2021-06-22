using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Navigate : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Web URL")]
        public InArgument<string> Url { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        { 
            string url = context.GetValue(this.Url);
            try
            {
                Internet_Explore.IE_Navigate(url);
                //ie.IE_Navigate(url);
                Result.Set(context, true);
            }
            catch
            { 
                Result.Set(context, false);
            }

        }
    }
}
