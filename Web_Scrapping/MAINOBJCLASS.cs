using System;
using System.Runtime.InteropServices;
using System.Threading;
using mshtml;
using SHDocVw;


namespace Web_Scrapping
{
    class MAINOBJCLASS
    {

        AutoResetEvent documentComplete;
        InternetExplorer explorer = new InternetExplorer();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        private const int SW_MAXIMISE = 3;

        //public void IECreate(string url, bool visibility)
        public void IECreate(string url)
        {
            explorer.DocumentComplete += OnIEDocumentComplete;
            documentComplete = new AutoResetEvent(false);
            object mVal = System.Reflection.Missing.Value;
            explorer.Navigate(url, ref mVal, ref mVal, ref mVal, ref mVal);
            documentComplete.WaitOne();
            explorer.Visible = true;
        }
        public void IE_Tag_Element(string TagName, string GetAttribute, string GetAttributeValue, string SetAttribute, string SetAttributeValue)
        {
            mshtml.HTMLDocument doc = explorer.Document;
            mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(TagName);
            //MessageBox.Show("TagName : " + TagName);
            foreach (mshtml.IHTMLElement elem in collection)
            {
                if (elem.getAttribute(GetAttribute) != null)
                {
                    //MessageBox.Show("GetAttribute : Not null");
                    if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
                    {
                        elem.setAttribute(SetAttribute, SetAttributeValue);
                        System.Windows.MessageBox.Show("SetAttribute : Setting");

                    }
                }
            }

        }

        private void OnIEDocumentComplete(object pDisp, ref object URL)
        {
            documentComplete.Set();
        }
    }
}
