using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelWriteCellByRange : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Position")]
        [RequiredArgument]
        public InArgument<string> RNG { get; set; }

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
            //try
            //{
                string rng = context.GetValue(this.RNG);
                string Data = context.GetValue(this.data);
                int sheet = context.GetValue(this.Sheet);
                string sheetName = context.GetValue(this.SheetName);

                //Excel_Core excel = new Excel_Core();
                Excel_Core.WriteCellByRange(rng, sheet,sheetName, Data);
            //}
            //catch
            //{

            //}
        }
    }
}
