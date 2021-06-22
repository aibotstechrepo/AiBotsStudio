using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelInvokeMacro : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Name of the macro")]
        [RequiredArgument]
        public InArgument<string> macroName { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Number")]
        public InArgument<int> SheetNumber { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {

            int sheetNumber = context.GetValue(this.SheetNumber);
            string sheetName = context.GetValue(this.SheetName);
            string MacroName = context.GetValue(this.macroName);
            Excel_Core.Invloke_Macros(MacroName,sheetNumber,sheetName);
        }
    }
}
