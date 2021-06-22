using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace Excel_Activity
{
    public sealed class ExcelCopyRow : CodeActivity
    {
        public InArgument<string> SourceFrom { get; set; }
        public InArgument<string> SourceTo { get; set; }
        public InArgument<string> DestinationFrom { get; set; }
        public InArgument<string> DestinationTo { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string sourcefrom = context.GetValue(this.SourceFrom);
            string sourceto = context.GetValue(this.SourceTo);
            string destinationfrom = context.GetValue(this.DestinationFrom);
            string destinationto = context.GetValue(this.DestinationTo);
            string error = null;
            try
            {
                Excel_Core.CopyRow(sourcefrom, sourceto, destinationfrom, destinationto);
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
