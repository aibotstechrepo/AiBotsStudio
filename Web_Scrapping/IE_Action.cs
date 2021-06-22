using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Action : CodeActivity
    {

        public enum propert
        {
            Click,
            Enable, 
            Disable,
            Focus,
            Blur
        }

        [Category("Input")]
        [DisplayName("Action")]
        public propert act { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Tag Name")]
        public InArgument<string> tag { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Attribute")]
        public InArgument<string> getatt { get; set; }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Attribute value")]
        public InArgument<string> getattval { get; set; } 

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            string Tag = context.GetValue(this.tag);
            string Gettatt = context.GetValue(this.getatt);
            string Getattval = context.GetValue(this.getattval);

            int acti = Convert.ToInt32(act);
            try
            {
                Internet_Explore.IE_Tag_Action(Tag, Gettatt, Getattval, acti); 
                Result.Set(context, true);
            }
            catch
            {
                Result.Set(context, false);
            }

        }
    }
}
