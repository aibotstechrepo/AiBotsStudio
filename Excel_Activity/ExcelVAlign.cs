using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelVAlign : CodeActivity
    {
        public enum Align
        {
            Left,
            Right,
            Center,
            Justify
        }
        [Category("Input")]
        [DisplayName("Align Type")]
        public Align al { get; set; }
        public InArgument<string> From { get; set; }
        public InArgument<string> To { get; set; }
        public InArgument<bool> Entire_Row { get; set; }
        public InArgument<bool> Entire_Column { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string from = context.GetValue(this.From);
            string to = context.GetValue(this.To);
            bool er = context.GetValue(this.Entire_Row);
            bool ec = context.GetValue(this.Entire_Column);
            int align = Convert.ToInt32(al);
            string error = null;
            try
            {
                if (align == 0)
                {
                    Excel_Core.V_Align_Left(from, to, er, ec);
                }
                else if (align == 1)
                {
                    Excel_Core.V_Align_Right(from, to, er, ec);
                }
                else if (align == 2)
                {
                    Excel_Core.V_Align_Center(from, to, er, ec);
                }
                else
                {
                    Excel_Core.V_Align_Justify(from, to, er, ec);
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
