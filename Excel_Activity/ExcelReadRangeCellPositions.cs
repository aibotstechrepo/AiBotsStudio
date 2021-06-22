using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelReadRangeCellPositions : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Row From")]
        [RequiredArgument]
        public InArgument<Int32> RowFrom { get; set; }

        [Category("Input")]
        [DisplayName("Column From")]
        [RequiredArgument]
        public InArgument<Int32> ColFrom { get; set; } 

        [Category("Input")]
        [DisplayName("Row To")]
        [RequiredArgument]
        public InArgument<Int32> RowTo { get; set; }

        [Category("Input")]
        [DisplayName("Column To")]
        [RequiredArgument]
        public InArgument<Int32> ColTo { get; set; }


        [Category("Output")]
        [DisplayName("Data")] 
        public OutArgument<string[,]> Data { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Number")]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int rowfrom = context.GetValue(this.RowFrom);
            int rowto = context.GetValue(this.RowTo);
            int colfrom = context.GetValue(this.ColFrom);
            int colto = context.GetValue(this.ColTo);
            int sheet = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);

            //Excel_Core excel = new Excel_Core();
            string[,] data = Excel_Core.ReadRangeCellPosition(rowfrom, colfrom, rowto, colto, sheet,sheetName);
            Data.Set(context, data);
        }
    }
}
