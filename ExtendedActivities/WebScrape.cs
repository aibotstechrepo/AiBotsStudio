using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace ExtendedActivities
{

    public sealed class WebScrape : CodeActivity
    {
        public InArgument<string[][]> TAG { get; set; }
        public OutArgument<string[,]> Data { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[][] a = context.GetValue(TAG);
            int a1 = a.GetUpperBound(0);
            //int a2 = a.GetUpperBound(1);
            string aa =     a[0][0];
            string aa1 =    a[0][1];
            string aa11 =   a[1][0];
            string aa111 =  a[1][1];
            string aa1111 = a[2][0];
            string aa11111 =a[3][0];
            string aa12 =   a[4][0];
            System.Windows.Forms.MessageBox.Show(a1.ToString());
            //System.Windows.Forms.MessageBox.Show(a2.ToString());
           
        }
    }
}
