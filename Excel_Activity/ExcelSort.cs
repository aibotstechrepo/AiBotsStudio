using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class ExcelSort : CodeActivity
    {
        public enum oper
        {
            Ascending,
            Descending
        }

        [Category("Input")]
        [DisplayName("Order")]
        public oper op { get; set; }

        [Category("Input")]
        [DisplayName("Column Number")] 
        public InArgument<int> Column { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int oval = Convert.ToInt32(op);
            int col = context.GetValue(this.Column);
            if(col>0)
            {
                Excel_Core.Sort(col, oval);
            }
        }
    }
}
