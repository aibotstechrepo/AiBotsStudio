using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsAddShape : CodeActivity
    {
        public InArgument<int> Type { get; set; }
        public InArgument<float> Left { get; set; }
        public InArgument<float> Top { get; set; }
        public InArgument<float> Width { get; set; }
        public InArgument<float> Height { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            int type = context.GetValue(this.Type);
            float left = context.GetValue(this.Left);
            float top = context.GetValue(this.Top);
            float width = context.GetValue(this.Width);
            float height = context.GetValue(this.Height);
            string error = null;
            try
            {
                WordCoreOperations.WordAddShape(type, left, top, width, height);
                context.SetValue(Error, error);
            }
            catch(Exception ex)
            {
                string[] errorArray = { };
                error = ex.ToString();
                context.SetValue(Error, error);
            }
        }
    }
}
