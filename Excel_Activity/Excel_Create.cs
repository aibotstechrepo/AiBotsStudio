using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Dynamic;
using System.Collections;
using System.ComponentModel;

namespace Excel_Activity
{

    public sealed class Excel_Create : CodeActivity
    {
        public enum Visibility
        {
            True,
            False
        }

        [Category("Input")]
        [DisplayName("Visibility")]
        public Visibility vis { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int visval = Convert.ToInt32(vis);
            bool visi = false;
            if (visval == 0)
            {
                visi = true;
            }
            if (visval == 1)
            {
                visi = false;
            }
            //Excel_Core a = new Excel_Core(@"d:\2.xlsx", 1,true);
            //a.ReadCellByPostion("a2");

            //Excel_Core excel = new Excel_Core();
            Excel_Core.Create_Workbook(visi); 
        }
    }
}
