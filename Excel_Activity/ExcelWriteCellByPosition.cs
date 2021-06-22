using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelWriteCellByPosition : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Row")]
        [RequiredArgument]
        public InArgument<Int32> Row { get; set; }

        [Category("Input")]
        [DisplayName("Column")]
        [RequiredArgument]
        public InArgument<Int32> Col { get; set; }

        [Category("Input")]
        [DisplayName("Data")]
        [RequiredArgument]
        public InArgument<string> data { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Number")]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int row = context.GetValue(this.Row);
            int col = context.GetValue(this.Col);
            int sheet = context.GetValue(this.Sheet);
            string Data = context.GetValue(this.data);
            string sheetName = context.GetValue(this.SheetName);

            //Excel_Core excel = new Excel_Core();
            Excel_Core.WriteCellByPosition(row, col, sheet,sheetName, Data);
        }
    }
}
