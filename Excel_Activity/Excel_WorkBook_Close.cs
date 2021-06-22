using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Excel_Activity
{

    public sealed class Excel_WorkBook_Close : CodeActivity
    { 
        protected override void Execute(CodeActivityContext context)
        {
            Excel_Core.close_WorkBook();
        }
    }
}
