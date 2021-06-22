using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class WebScrapByTagName : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Tag Name")]
        [RequiredArgument]
        public InArgument<string> TAG { get; set; }

        [Category("Input")]
        [DisplayName("Attribute")]
        [RequiredArgument]
        public InArgument<string> ATT { get; set; }

        [Category("Output")]
        [DisplayName("Data")] 
        public OutArgument<string[]> Data { get; set; }

        [Category("Filter")]
        [DisplayName("Attribute")]
        //[RequiredArgument]
        public InArgument<string> FATT { get; set; }

        [Category("Filter")]
        [DisplayName("Attribute Value")]
        //[RequiredArgument]
        public InArgument<string> FAV { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string tag = context.GetValue(TAG);
            string att = context.GetValue(ATT);
            string fatt = context.GetValue(FATT);
            string fav = context.GetValue(FAV);
            string[] data = Internet_Explore.DataScrapByTag_Attribute(tag, att,fatt,fav);
            Data.Set(context, data);
        }
    }
}
