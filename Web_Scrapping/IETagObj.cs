using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Scrapping
{
    class IETagObj
    {
        SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();


        internal void IEcreate(string url, bool visible)
        {
            ie.Navigate(url);
            //MessageBox.Show("IE Create Trigger");
            ie.Visible = visible;
        }

        internal void IENavigate(string url)
        {
            ie.Navigate(url);
        }

        internal void IELoadwait()
        {
            //MessageBox.Show(ie.ReadyState.ToString());
            while (ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
            {
                Application.DoEvents();
            }
            mshtml.HTMLDocument doc = ie.Document;
            while (doc.readyState != "complete")
            {
                Application.DoEvents();
            }
        }
         
        internal void Element(string TagName, string GetAttribute, string GetAttributeValue, string SetAttribute, string SetAttributeValue)
        {
            mshtml.HTMLDocument doc = ie.Document;
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
                        //MessageBox.Show("SetAttribute : Setting");
                    }
                }
            }
        }
        internal void SelectBox1(string SelectBoxTagName, int OptionIndex, bool InFrame = false)
        {
            if (InFrame)
            {
                mshtml.HTMLDocument doc = ie.Document;
                IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
                foreach (IHTMLElement iel in allFrames)
                {
                    string a = iel.getAttribute("name");
                    HTMLFrameElement frm = (HTMLFrameElement)iel;
                    DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;

                    mshtml.IHTMLSelectElement lists = (mshtml.IHTMLSelectElement)doc1.all.item(SelectBoxTagName, 0);
                    mshtml.HTMLElementCollection options = (mshtml.HTMLElementCollection)lists.options;
                    mshtml.HTMLOptionElement option = (mshtml.HTMLOptionElement)options.item(OptionIndex);
                    lists.selectedIndex = OptionIndex;
                }
            }
            else
            {
                mshtml.HTMLDocument doc = ie.Document;
                mshtml.IHTMLSelectElement lists = (mshtml.IHTMLSelectElement)doc.all.item(SelectBoxTagName, 0);
                mshtml.HTMLElementCollection options = (mshtml.HTMLElementCollection)lists.options;
                mshtml.HTMLOptionElement option = (mshtml.HTMLOptionElement)options.item(OptionIndex);
                lists.selectedIndex = OptionIndex;
            }
        }
    }
}
