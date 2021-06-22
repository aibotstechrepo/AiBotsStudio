using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Body_Read_Html : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Website URL")]
        public InArgument<string> url { get; set; }

        [Category("Output")]
        [DisplayName("Html Code")]
        public OutArgument<string> hc { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            string Url = context.GetValue(this.url);
            string data = "";
            try
            {
                data = Internet_Explore.IE_Body_readHTML(Url);
                hc.Set(context, data);Result.Set(context, true);
            }
            catch
            {
                hc.Set(context, "");
                Result.Set(context, false);
            }
        
        }
    }
}
