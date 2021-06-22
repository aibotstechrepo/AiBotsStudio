using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelRenameSheet : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Sheet Number")]
        //[RequiredArgument]
        public InArgument<Int32> SheetNumber { get; set; }
        [Category("Input")]
        [DisplayName("New Sheet Name")]
        [RequiredArgument]
        public InArgument<string> SheetNameNew { get; set; }

        [Category("Input")]
        [DisplayName("Old Sheet Name")]
        //[RequiredArgument]
        public InArgument<string> SheetNameOld { get; set; }

        [Category("Error")]
        [DisplayName("Message")] 
        public OutArgument<string> Error_Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        { 
            int sheetNumber = context.GetValue(this.SheetNumber);
            string sheetNameold = context.GetValue(this.SheetNameOld);
            string sheetNamenew = context.GetValue(this.SheetNameNew);
            //Excel_Core excel = new Excel_Core();
            string a = Excel_Core.renameSheet(sheetNumber,sheetNameold,sheetNamenew);
            Error_Message.Set(context, a);
        }
    }
}
