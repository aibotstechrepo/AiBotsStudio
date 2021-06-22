using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace File_Operations
{

    public sealed class PDF_Text_Read : CodeActivity
    {
        [Category("Input")]
        [DisplayName("File")]
        [RequiredArgument]
        public InArgument<string> file { get; set; }

        [Category("Output")]
        [DisplayName("Text")]
        public OutArgument<string> Text { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{ 
                string text = context.GetValue(this.file);
                string a = PDFTextReader(@"" + text);
                Text.Set(context, a);
                if(a== "not found")
                { 
                    Result.Set(context, false);
                }
                else
                {
                    Result.Set(context, true);
                }
            //}
            //catch
            //{
            //    Result.Set(context, false); 
            //}
        }

        public string PDFTextReader(string filename)
        {
            //try
            //{ 
                StringBuilder text1 = new StringBuilder();
                //using (PdfReader reader = new PdfReader(@"E:\AIBOTS_Production\autoit_Programs\Jagdeesh\invoice processing\Invoice PDF\INV-3288-Proline.pdf"))
                if (File.Exists(filename))
                {
                    using (PdfReader reader = new PdfReader(filename))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text1.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                    }
                }
                // System.Windows.Forms.MessageBox.Show(text1.ToString());
                return text1.ToString();

        }
    }
}
