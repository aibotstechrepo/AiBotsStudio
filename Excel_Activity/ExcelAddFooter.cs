using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelAddFooter : CodeActivity
    {
        public enum Footer
        {
            Left,
            Right,
            Center
        }
        [Category("Input")]
        [DisplayName("Footer Type")]
        public Footer ft { get; set; }
        public InArgument<string> PageNumber { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string pagenumber = context.GetValue(this.PageNumber);
            string error = null;
            int footer = Convert.ToInt32(ft);
            try
            {
                if(footer == 0)
                {
                    Excel_Core.LeftFooter(pagenumber);
                }
                else if(footer == 1)
                {
                    Excel_Core.RightFooter(pagenumber);
                }
                else if(footer == 2)
                {
                    Excel_Core.CenterFooter(pagenumber);
                }
            }
            catch (Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }
        }

    }
}
