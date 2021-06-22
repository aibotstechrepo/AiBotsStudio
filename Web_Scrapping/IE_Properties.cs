using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Properties : CodeActivity
    {
        public enum propert
        {
            Current_URL,
            Title ,
            Text, 
            HTML
        }

        [Category("Input")]
        [DisplayName("Retrive")]
        public propert prop { get; set; }

        [Category("Output")]
        [DisplayName("Property Value")]
        public OutArgument<string> pv { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            int props = Convert.ToInt32(prop);
            string val = "";
            val = Internet_Explore.IE_Property(props);
            pv.Set(context, val);
            //if (props == 0)
            //{
            //    val = Internet_Explore.IE_Property(0);
            //    pv.Set(context, val);
            //}
            //else if(props == 1)
            //{

            //}
        }
    }
}
