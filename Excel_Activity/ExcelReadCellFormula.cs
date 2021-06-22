using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelReadCellFormula : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Cell")]
        //[RequiredArgument]
        public InArgument<string> Cell { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Number")]
        public InArgument<int> SheetNumber { get; set; }

        [Category("Output")]
        [DisplayName("Formula")]
        public OutArgument<string> Formula { get; set; }


        protected override void Execute(CodeActivityContext context)
        { 
            string text = context.GetValue(this.Cell);
            int sheetNumber = context.GetValue(this.SheetNumber);
            string sheetName = context.GetValue(this.SheetName);
            string d = Excel_Core.ReadCellFormula(text,sheetNumber,sheetName);
            Formula.Set(context, d);
        }
    }
}
