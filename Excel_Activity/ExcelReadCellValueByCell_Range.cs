using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelReadCellValueByCell_Range : CodeActivity
    { 
        [Category("Input")]
        [DisplayName("Position")]
        [RequiredArgument]
        public InArgument<string> RNG { get; set; }

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
            try
            {
                string rng = context.GetValue(this.RNG);
                int sheet = context.GetValue(this.Sheet);
                string sheetName = context.GetValue(this.SheetName);

                ///Excel_Core excel = new Excel_Core();
                string data = Excel_Core.ReadCellByRange(rng, sheet, sheetName);
                Data.Set(context, data);
            }
            catch
            {
                Data.Set(context, "");
            }
        }
    }
}
