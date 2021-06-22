using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelReadCellValueByCell_I_J_value : CodeActivity
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
        [DisplayName("Sheet Number")]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        [Category("Output")]
        [DisplayName("Data")]
        public OutArgument<string> Data { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int row = context.GetValue(this.Row);
            int col = context.GetValue(this.Col);
            int sheet = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);

            //Excel_Core excel = new Excel_Core();
            string data = Excel_Core.ReadCellByPosition(row, col, sheet,sheetName);
            Data.Set(context, data);
        }
    }
}
