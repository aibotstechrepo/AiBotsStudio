using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Loadwait : CodeActivity
    {
        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //[Category("Output")]
        //[DisplayName("Current State")]
        //public OutArgument<string> state { get; set; }

       // Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                //string a = ie.IELoadwait();
                Internet_Explore.IELoadwait();
                //state.Set(context, a);
                Result.Set(context, true);
            }
            catch
            {
                Result.Set(context, false);
            }
             
        }
    }
}
