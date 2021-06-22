using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Custom_Control
{
    
    public sealed class PhoenixOCR : CodeActivity
    {
        CustomFunction a = new CustomFunction();
        protected override void Execute(CodeActivityContext context)
        {
            System.Windows.Forms.MessageBox.Show( a.PheniexOCR(@"‪D:/Test123.pdf"));
        }
    }
}
