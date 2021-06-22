using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net;
using System.IO; 
using System.Windows.Forms;
using mshtml;
using System.Xml;
using System.ComponentModel;

namespace Web_Scrapping
{

    public sealed class IE_Body_Read_Text : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        [DisplayName("Website URL")]
        public InArgument<string> url { get; set; }

        [Category("Output")]
        [DisplayName("Text from webpage")]
        public OutArgument<string> hc { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        //Internet_Explore ie = new Internet_Explore();

        protected override void Execute(CodeActivityContext context)
        {
            string Url = context.GetValue(this.url);
            string data = "";
            try
            {
                // MessageBox.Show("try");
                //string temp = Url.Substring(0, 2);
                //MessageBox.Show(temp);
                data = Internet_Explore.IE_Get_Text(Url);
                hc.Set(context, data); Result.Set(context, true);
               // MessageBox.Show("close");
            }
            catch
            {
               // MessageBox.Show("catch");
                hc.Set(context, "");
                Result.Set(context, false);
            }

        }

        //// Define an activity input argument of type string
        //public InArgument<string> Text { get; set; }

        //// If your activity returns a value, derive from CodeActivity<TResult>
        //// and return the value from the Execute method.
        //protected override void Execute(CodeActivityContext context)
        //{
        //    XmlDocument document = new XmlDocument();
        //    document.Load("http://www.facebook.com");
        //    string allText = document.InnerText;
        //    System.Windows.MessageBox.Show(allText);
        //}
        //void function1()
        //{
        //    string text = "";
        //    string url = "http://csharp.net-informations.com/communications/csharp-url-content.htm";
        //    StreamReader inStream;
        //    WebRequest webRequest;
        //    WebResponse webresponse;
        //    webRequest = WebRequest.Create(url);
        //    webresponse = webRequest.GetResponse();
        //    inStream = new StreamReader(webresponse.GetResponseStream());
        //    text = inStream.ReadToEnd();
        //    System.Windows.MessageBox.Show(text);
        //}
        //void function2()
        //{
        //    Uri urlPath = new Uri("http://www.facebook.com/");
        //    System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();  
        //    wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DisplayText);
        //    wb.Url = urlPath;
        //}
        //private void DisplayText(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    string data = "";
        //    WebBrowser wb = (WebBrowser)sender;
        //    IHTMLDocument2 htmlDocument =  wb.Document.DomDocument as IHTMLDocument2; 
        //    wb.Document.ExecCommand("SelectAll", false, null);
        //    IHTMLSelectionObject currentSelection = htmlDocument.selection;
        //    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
        //    data= range.text;
        //    MessageBox.Show(data);


        //}



    }
}
