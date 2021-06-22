using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace AibotsRPA.Custom_Controls
{

    public sealed class Pdf_to_string : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);

            StringBuilder text1 = new StringBuilder();
            using (PdfReader reader = new PdfReader(@"E:\AIBOTS_Production\autoit_Programs\Jagdeesh\invoice processing\Invoice PDF\INV-3288-Proline.pdf"))
            {
                for(int i=1; i<=reader.NumberOfPages; i++)
                {
                    text1.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            System.Windows.Forms.MessageBox.Show(text1.ToString());

        }
    }
}
