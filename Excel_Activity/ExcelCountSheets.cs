using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelCountSheets : CodeActivity
    { 
        [Category("Output")]
        [DisplayName("Number of Sheets")] 
        public OutArgument<Int32> Count { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int count = Excel_Core.numberOfSheets();
            Count.Set(context, count);
        }
    }
}
