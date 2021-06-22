using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelProtectPassword : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Sheet Number")]
        //[RequiredArgument]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        [Category("Input")]
        [DisplayName("Password")]
        [RequiredArgument]
        public InArgument<string> pwd { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int sh = context.GetValue(this.Sheet); 
            string sheetName = context.GetValue(this.SheetName);
            string pass = context.GetValue(this.pwd);
            Excel_Core.ProtectSheet(sh,sheetName, pass);
        }
    }
}
