using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelSheetNames : CodeActivity
    {

        [Category("Output")]
        [DisplayName("Sheet Names")] 
        public OutArgument<string[]> SheetName { get; set; } 

        protected override void Execute(CodeActivityContext context)
        {
            string[] sheetNames = Excel_Core.ListOFSheetNames(); 
            SheetName.Set(context,sheetNames);
        }
    }
}
