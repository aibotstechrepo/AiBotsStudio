using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelSetBorder : CodeActivity
    {
        public enum Border
        {
            Top,
            Bottom,
            Left,
            Right
        }
        [Category("Input")]
        [DisplayName("Border Type")]
        public Border br { get; set; }
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            int border = Convert.ToInt32(br);
            string error = null;
            try
            {
                if (border == 0)
                {
                    Excel_Core.BorderTop(from, to);
                }
                else if (border == 1)
                {
                    Excel_Core.BorderBottom(from, to);
                }
                else if (border == 2)
                {
                    Excel_Core.BorderLeft(from, to);
                }
                else
                {
                    Excel_Core.BorderRight(from, to);
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
