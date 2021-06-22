using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using Fontss = iTextSharp.text.Font;
using System.ComponentModel;

namespace File_Operations
{
    public sealed class PDFAddLink : CodeActivity
    {
        [Category("Input")]
        [DisplayName("PDF FilePath/Name")]
        [RequiredArgument]
        public InArgument<string> FilePath { get; set; }

        [Category("Input")]
        [DisplayName("Link")]
        [RequiredArgument]
        public InArgument<string> Link { get; set; }

        [Category("Input")]
        [DisplayName("Link Title")]
        [RequiredArgument]
        public InArgument<string> Title { get; set; }

        [Category("Input")]
        [DisplayName("X")]
        [RequiredArgument]
        public InArgument<int> X { get; set; }

        [Category("Input")]
        [DisplayName("Y")]
        [RequiredArgument]
        public InArgument<int> Y { get; set; }

        [Category("Output")]
        [DisplayName("Error")]
        public OutArgument<string> Error { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            string pathin = context.GetValue(this.FilePath);
            string error = null;
            try
            {
                string pathout = $"{ Path.GetDirectoryName(pathin) }{"\\temp.pdf"}";
                using (PdfReader reader = new PdfReader(pathin))
                using (PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.OpenOrCreate)))
                {
                    int x = context.GetValue(this.X);
                    int y = context.GetValue(this.Y);
                    string title = context.GetValue(this.Title);
                    string link = context.GetValue(this.Link);
                    var pageSize = reader.GetPageSize(1);
                    PdfContentByte pbover = stamper.GetOverContent(1);
                    Fontss font = new Fontss();
                    font.Size = 45;
                    Point point = new Point(x, y);
                    x = point.X;
                    y = point.Y;
                    y = (int)(pageSize.Height - y);
                    var anchor = new Chunk(title)
                    {
                        Font = new Fontss(Fontss.FontFamily.HELVETICA, 25, Fontss.NORMAL, BaseColor.BLUE)
                    };
                    anchor.SetAnchor(link);
                    Paragraph p = new Paragraph()
                    {
                        Alignment = Element.ALIGN_CENTER,
                        IndentationLeft = 90
                    };
                    p.SetLeading(12.1f, 12.1f);
                    p.Add(anchor);
                    ColumnText.ShowTextAligned(pbover, Element.ALIGN_CENTER, p, x, y, 0);
                }
                File.Delete(pathin);
                System.IO.File.Move(pathout, pathin);
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
