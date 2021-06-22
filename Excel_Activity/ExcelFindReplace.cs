using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelFindReplace : CodeActivity
    {
        public enum oper
        {
            Part,
            Whole_Word            
        }

        [Category("Input")]
        [DisplayName("Match Word")]
        public oper op { get; set; }

        [Category("Input")]
        [DisplayName("Case Sensitive")]
        [DefaultValue(false)]
        public Boolean Case { get; set; }

        [Category("Input")]
        [DisplayName("Find")]
        [RequiredArgument]
        public InArgument<string> find { get; set; }

        [Category("Input")]
        [DisplayName("Replace")]
        [RequiredArgument]
        public InArgument<string> replace { get; set; }


        protected override void Execute(CodeActivityContext context)
        {

            int oval = Convert.ToInt32(op);
            string Find = context.GetValue(this.find);
            string Replace = context.GetValue(this.replace);

            Excel_Core.FindReplace(Find, Replace, Case, oval);
        }
    }
}
