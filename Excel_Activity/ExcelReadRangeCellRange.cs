using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Data;

namespace Excel_Activity
{

    public sealed class ExcelReadRangeCellRange : CodeActivity
    {

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

        [Category("Output")]
        [DisplayName("Data")]
        public OutArgument<DataTable> Data { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            string start = context.GetValue(this.Start);
            string end = context.GetValue(this.End); 
            int sheet = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);

            //Excel_Core excel = new Excel_Core();
            DataTable data = Excel_Core.ReadRangeCellRange(start, end, sheet,sheetName);
            Data.Set(context, data);
        }
    }
}
