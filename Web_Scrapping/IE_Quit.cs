using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Quit : CodeActivity
    {
        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                Internet_Explore.IEQuit();
                Result.Set(context, true);
            }
            catch
            {
                Result.Set(context, false);
            }
            
        }
    }
}
