using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Excel_Activity
{

    public sealed class ExcelSave : CodeActivity
    {
         
        protected override void Execute(CodeActivityContext context)
        {
            //Excel_Core excel = new Excel_Core();
            Excel_Core.save();
        }
    }
}
