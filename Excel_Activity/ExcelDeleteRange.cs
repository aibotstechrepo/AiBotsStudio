using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;

namespace Excel_Activity
{
    
    public sealed class ExcelDeleteRange : CodeActivity
    { 
        public enum oper
        {
            None,
            Shift_Cells,
            Shift_Rows
        }

        [Category("Input")]
        [DisplayName("Shift")]
        public oper op { get; set; }

        [Category("Input")]
        [DisplayName("Range From")]
        [RequiredArgument]
        public InArgument<string> Start { get; set; }

        [Category("Input")]
        [DisplayName("Range To")]
        [RequiredArgument]
        public InArgument<string> End { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Number")]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string start = context.GetValue(this.Start);
            string end = context.GetValue(this.End);
            int sheetNumber = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);
            int oval = Convert.ToInt32(op);
            Excel_Core.DeleteRange(start, end, sheetNumber,sheetName, oval);
        }
    }
}
