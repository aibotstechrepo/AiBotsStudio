using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsAddTable : CodeActivity
    {
        public InArgument<int> Rows { get; set; }
        public InArgument<int> Columns { get; set; }
        public InArgument<int> SpaceAfter { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int rows = context.GetValue(this.Rows);
            int cols = context.GetValue(this.Columns);
            int spaceafter = context.GetValue(this.SpaceAfter);
            string error = null;

            try
            {
                WordCoreOperations.WordAddTable(rows, cols, spaceafter);
                context.SetValue(Error, error);
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
