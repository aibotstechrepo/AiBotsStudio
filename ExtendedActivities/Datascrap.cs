using mshtml;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtendedActivities
{
    //class Datascrap
    //{
    //    public static InternetExplorer ie = new InternetExplorer();
    //    public void data()
    //    {
    //        IE_Create("https://www.tutorialspoint.com/tutorialslibrary.htm", 0, 0);

    //        Thread.Sleep(6000);
    //    mshtml.HTMLDocument doc = ie.Document;
    //        mshtml.IHTMLElementCollection c = ((mshtml.HTMLDocumentClass)(doc)).getElementsByTagName("a");
    //        foreach (IHTMLElement div in c)
    //        {
    //            string a = div.innerText;
    //            if (div.className == "featured-box")
    //            if (div.getAttribute("href").Equals(""))
    //            {
    //                IHTMLDOMNode divNode = (IHTMLDOMNode)div;

    //                IHTMLDOMChildrenCollection children = (IHTMLDOMChildrenCollection)divNode.childNodes;

    //                foreach (IHTMLDOMNode child in children)
    //                {
                            
    //                    Console.WriteLine(child.nodeValue);
    //                }
    //            }
    //        }
    //        IHTMLElement element = doc.getElementById("input1");
    //        // get a collection of all attributes
    //        IHTMLAttributeCollection attributes = (IHTMLAttributeCollection)((IHTMLDOMNode)element).attributes;
    //        // iterate all attributes
    //        for (int i = 0; i < attributes.length; i++)
    //        {
    //            IDispatchImplAttribute attribute = attributes.item(i);

    //            // this eventually lists your attribute
    //            System.Diagnostics.Debug.WriteLine(((IHTMLDOMAttribute)attribute).specified(");
    //        }
    //    }


    //    [DllImport("user32.dll")]
    //    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    //    //private const int SW_MAXIMISE = 3;

    //    public static void IE_Create(string url, int visib, int winstate)
    //    {
    //    Data:
    //        try
    //        {
    //            ie.ToolBar = 0;
    //            ie.StatusBar = true;
    //            ie.MenuBar = true;
    //            ie.AddressBar = true;
    //            if (visib == 0)
    //            {
    //                ie.Visible = true;
    //            }
    //            else if (visib == 1)
    //            {
    //                ie.Visible = false;
    //            }

    //            if (winstate == 0)
    //            {
    //                ShowWindow((IntPtr)ie.HWND, 3);
    //            }
    //            else if (winstate == 1)
    //            {
    //                ShowWindow((IntPtr)ie.HWND, 2);
    //            }
    //            else if (winstate == 2)
    //            {
    //                ie.Width = 800;
    //                ie.Height = 600;
    //            }
    //            if (url == null) url = "www.google.com";
    //            ie.Navigate2(url);
    //            while (ie.Busy) { System.Threading.Thread.Sleep(500); }
    //            //MessageBox.Show("ok");
    //            //ie.Navigate2("https://in.linkedin.com/");
    //            //System.Threading.Thread.Sleep(5000);
    //            //string TagName = "input"; string GetAttribute = "id"; string GetAttributeValue = "reg-firstname"; string SetAttribute = "value"; string SetAttributeValue= "From Bot";
    //            //mshtml.HTMLDocument doc = ie.Document;
    //            //mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(TagName);
    //            ////MessageBox.Show("TagName : " + TagName);
    //            //foreach (mshtml.IHTMLElement elem in collection)
    //            //{
    //            //    if (elem.getAttribute(GetAttribute) != null)
    //            //    {
    //            //        //MessageBox.Show("GetAttribute : Not null");
    //            //        if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
    //            //        {
    //            //            elem.setAttribute(SetAttribute, SetAttributeValue);
    //            //            //MessageBox.Show("SetAttribute : Setting");

    //            //        }
    //            //    }
    //            //}
    //        }
    //        catch
    //        {
    //            InternetExplorer ieq = new InternetExplorer();
    //            ie = ieq;
    //            goto Data;
    //        }
    //    }

    //}
}
