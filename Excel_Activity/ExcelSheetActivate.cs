using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelSheetActivate : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Sheet number")]
        // [RequiredArgument]
        public InArgument<Int32> SheetNumber { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Name")]
        // [RequiredArgument]
        public InArgument<string> SheetName { get; set; }
        protected override void Execute(CodeActivityContext context)
        {

            string sheetName = context.GetValue(SheetName);
            int sheetNumber = context.GetValue(SheetNumber);

            Excel_Core.SheetActivate(sheetNumber, sheetName);
        }
    }
}
