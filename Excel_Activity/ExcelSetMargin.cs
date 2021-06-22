using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelSetMargin : CodeActivity
    {
        public enum Margin
        {
            Top,
            Bottom,
            Left,
            Right
        }
        [Category("Input")]
        [DisplayName("Margin Type")]
        public Margin marg { get; set; }
        public InArgument<double> Thickness { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            double thickness = context.GetValue(this.Thickness);
            int margin = Convert.ToInt32(marg);
            string error = null;
            try
            {
                if (margin == 0)
                {
                    Excel_Core.SetMarginTop(thickness);
                }
                else if (margin == 1)
                {
                    Excel_Core.SetMarginBottom(thickness);
                }
                else if (margin == 2)
                {
                    Excel_Core.SetMarginLeft(thickness);
                }
                else
                {
                    Excel_Core.SetMarginRight(thickness);
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
