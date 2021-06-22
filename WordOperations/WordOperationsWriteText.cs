using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Word = Microsoft.Office.Interop.Word;
using System.Threading.Tasks;

namespace WordOperations
{
    public sealed class WordOperationsWriteText : CodeActivity
    {
        public InArgument<int> FontSize { get; set; }
        public InArgument<string> FontName { get; set; }
        public InArgument<int> FontType { get; set; }
        public InArgument<Word.WdColor> FontColor { get; set; }
        public InArgument<int> SpaceAfter { get; set; }
        public InArgument<string> Message { get; set; }
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string message = context.GetValue(this.Message);
            int fontsize = context.GetValue(this.FontSize);
            string fontname = context.GetValue(this.FontName);
            int fonttype = context.GetValue(this.FontType);
            Word.WdColor fontcolor = context.GetValue(this.FontColor);
            int spaceafter = context.GetValue(this.SpaceAfter);

            string error = null;

            try
            {
                WordCoreOperations.WordWriteText(message, fontsize, fontname, fonttype, fontcolor, spaceafter);
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
