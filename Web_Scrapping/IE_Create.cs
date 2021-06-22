using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{
    
    public sealed class IE_Create : CodeActivity 
    {

        public enum vis
        {
            True,
            False
        }
        public enum winstate
        {
            Maximized,
            Minimized,
            Normal
        }


        [Category("Input")]
        [DisplayName("Visibility")]
        public vis visval { get; set; }

        [Category("Input")]
        [DisplayName("Windows State")]
        public winstate winval { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Web URL")]
        public InArgument<string> url { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        // Internet_Explore ie = new Internet_Explore();
        //internal MAINOBJCLASS ie = new MAINOBJCLASS();

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                int visbs = Convert.ToInt32(visval);
                int visb = 0;
                int wins = Convert.ToInt32(winval);
                string url = context.GetValue(this.url);
                if(visbs == 0)
                {
                    visb = 0;
                }
                else if(visbs == 1)
                {
                    visb = 1;
                }
                else
                {
                    visb = 0;
                }
            //ie.IE_Create(url, visb, wins);
            Internet_Explore.IE_Create(url, visb, wins);
            //ie.IECreate("www.facebook.com");
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //} 
        }

    }
}
