using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IESelectDropDown : CodeActivity
    {
        [Category("Frame")]
        [RequiredArgument]
        [DisplayName("Name")]
        public InArgument<string> FrameName { get; set; }
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("ID")]
        public InArgument<string> ID { get; set; }
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Options")]
        public InArgument<string> option { get; set; }

        protected override void Execute(CodeActivityContext context)
        { 
            string id = context.GetValue(this.ID);
            string options = context.GetValue(this.option);
            string frameName = context.GetValue(this.FrameName);
            Internet_Explore.SelectBox(id, options, frameName);
        }
    }
}
