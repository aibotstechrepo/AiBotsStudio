using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{ 
    public sealed class IE_Tag_Input : CodeActivity
    {

        [Category("Targeting Tag")]
        [RequiredArgument]
        [DisplayName("Tag Name")]
        public InArgument<string> tag { get; set; }

        [Category("Targeting Tag")]
        [RequiredArgument]
        [DisplayName("Attribute")]
        public InArgument<string> getatt { get; set; }

        [Category("Targeting Tag")]
        [RequiredArgument]
        [DisplayName("Attribute value")]
        public InArgument<string> getattval { get; set; }

        [Category("Set info")]
        [RequiredArgument]
        [DisplayName("Set Attrbute")]
        public InArgument<string> setatt { get; set; }

        [Category("Set info")]
        [RequiredArgument]
        [DisplayName("Set Attribute Value")]
        public InArgument<string> setattval { get; set; }
         
        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            string Tag = context.GetValue(this.tag);
            string Gettatt = context.GetValue(this.getatt);
            string Getattval = context.GetValue(this.getattval);
            string Setatt = context.GetValue(this.setatt);
            string Setattval = context.GetValue(this.setattval);
            //try
            //{
                Internet_Explore.IE_Tag_Element(Tag, Gettatt, Getattval, Setatt, Setattval);
               // IE_Create a = new IE_Create();
                ///a.ie.IE_Tag_Element(Tag, Gettatt, Getattval, Setatt, Setattval);
                //Internet_Explore.IE_Tag_Element(Tag, Gettatt, Getattval, Setatt, Setattval);
                Result.Set(context, true);
            //}
            //catch
            //{
            //    Result.Set(context, false);
            //}
            
        }
    }
}
