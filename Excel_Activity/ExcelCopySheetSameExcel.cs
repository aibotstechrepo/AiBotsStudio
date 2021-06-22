using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelCopySheetSameExcel : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Sheet Number")]
        //[RequiredArgument]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int sheet = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);
            // Excel_Core excel = new Excel_Core();
            Excel_Core.CopySheet(sheetName,sheet);
        }
    }
}
