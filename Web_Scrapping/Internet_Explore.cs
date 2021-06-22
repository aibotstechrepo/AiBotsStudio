using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SHDocVw;
using System.Text.RegularExpressions;
using mshtml;
using System.Net;

namespace Web_Scrapping
{
    public static class Internet_Explore
    {
        public static InternetExplorer ie = new InternetExplorer();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        //private const int SW_MAXIMISE = 3;

        public static void IE_Create(string url, int visib, int winstate)
        {
        Data:
            try
            {
                ie.ToolBar = 0;
                ie.StatusBar = true;
                ie.MenuBar = true;
                ie.AddressBar = true;
                if (visib == 0)
                {
                    ie.Visible = true;
                }
                else if (visib == 1)
                {
                    ie.Visible = false;
                }

                if (winstate == 0)
                {
                    ShowWindow((IntPtr)ie.HWND, 3);
                }
                else if (winstate == 1)
                {
                    ShowWindow((IntPtr)ie.HWND, 2);
                }
                else if (winstate == 2)
                {
                    ie.Width = 800;
                    ie.Height = 600;
                }
                if (url == null) url = "www.google.com";
                ie.Navigate2(url);
                while (ie.Busy) { System.Threading.Thread.Sleep(500); }
                //MessageBox.Show("ok");
                //ie.Navigate2("https://in.linkedin.com/");
                //System.Threading.Thread.Sleep(5000);
                //string TagName = "input"; string GetAttribute = "id"; string GetAttributeValue = "reg-firstname"; string SetAttribute = "value"; string SetAttributeValue= "From Bot";
                //mshtml.HTMLDocument doc = ie.Document;
                //mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(TagName);
                ////MessageBox.Show("TagName : " + TagName);
                //foreach (mshtml.IHTMLElement elem in collection)
                //{
                //    if (elem.getAttribute(GetAttribute) != null)
                //    {
                //        //MessageBox.Show("GetAttribute : Not null");
                //        if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
                //        {
                //            elem.setAttribute(SetAttribute, SetAttributeValue);
                //            //MessageBox.Show("SetAttribute : Setting");

                //        }
                //    }
                //}
            }
            catch(SystemException)
            {
                
                    System.Threading.Thread.Sleep(500);
                    //goto Data;
                
               InternetExplorer ieq = new InternetExplorer();
                ie = ieq;
                goto Data;
            }
        }

        public static void IELoadwait()
        {
            //MessageBox.Show(ie.ReadyState.ToString());

            while (ie.Busy) { System.Threading.Thread.Sleep(500); }
            //while (ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_LOADED)
            //{
            //    System.Threading.Thread.Sleep(500);
            //    //Application.DoEvents();
            //}
            //return ie.ReadyState.ToString();
            //while (ie.Busy)
            //{

            //}

            //mshtml.HTMLDocument doc = ie.Document;
            //while (doc.readyState != "complete")
            //{
            //    Application.DoEvents();
            //}
        }

        public static string IE_Property(int pos)
        {
            if (pos == 0)
            {
                mshtml.HTMLDocument doc = ie.Document;
                return doc.url.ToString();

                //foreach (InternetExplorer ie in new ShellWindows())
                //{
                //   return ie.LocationURL.ToString();
                //}
            }
            else if(pos == 1)
            {
                mshtml.HTMLDocument doc = ie.Document;
                return doc.title;

            }
            else if(pos == 2)
            {
                mshtml.HTMLDocument doc = ie.Document;
                string Data = "";
                 
                mshtml.IHTMLElementCollection collection = doc.getElementsByTagName("body");
                foreach (mshtml.IHTMLElement elem in collection)
                {
                    if (elem.getAttribute("innerText") != null)
                    {
                        Data= Data+ elem.getAttribute("innerText");
                    }
                }
                
                IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
                foreach (IHTMLElement iel in allFrames)
                {

                    HTMLFrameElement frm = (HTMLFrameElement)iel;
                    DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;
                    mshtml.IHTMLElementCollection collection1 = doc1.getElementsByTagName("body");
                    //MessageBox.Show("TagName : " + TagName);
                    foreach (mshtml.IHTMLElement elem in collection1)
                    {
                        if (elem.getAttribute("innerText") != null)
                        {
                            Data = Data + elem.getAttribute("innerText");
                        }
                    }

                }
                return Data;
            }
            else if (pos == 3)
            {
                mshtml.HTMLDocument doc = ie.Document;
                string Data = "";

                mshtml.IHTMLElementCollection collection = doc.getElementsByTagName("body");
                foreach (mshtml.IHTMLElement elem in collection)
                {
                    if (elem.getAttribute("innerHTML") != null)
                    {
                        Data= Data+ elem.getAttribute("innerHTML");
                    }
                }

                IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
                foreach (IHTMLElement iel in allFrames)
                {

                    HTMLFrameElement frm = (HTMLFrameElement)iel;
                    DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;
                    
                    mshtml.IHTMLElementCollection collection1 = doc1.getElementsByTagName("body");
                    //MessageBox.Show("TagName : " + TagName);
                    foreach (mshtml.IHTMLElement elem in collection1)
                    {
                        if (elem.getAttribute("innerHTML") != null)
                        {
                            Data = Data + elem.getAttribute("innerHTML");
                        }
                    }

                }
                return Data;
            }
            else
            {
                return null;
            }

        }

        public static void IE_Tag_Element(string TagName, string GetAttribute, string GetAttributeValue, string SetAttribute, string SetAttributeValue)
        {
            mshtml.HTMLDocument doc = ie.Document;


            mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(TagName);
            //MessageBox.Show("TagName : " + TagName);
            foreach (mshtml.IHTMLElement elem in collection)
            {
                if (elem.getAttribute(GetAttribute) != null)
                {

                    //try
                    //{
                    //    string a = elem.getAttribute(GetAttribute);
                    //}
                    //catch
                    //{
                    //    ;
                    //}
                    //MessageBox.Show("GetAttribute : Not null");
                    if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
                    {
                        if (TagName == "combobox" || TagName == "select")
                        {
                            elem.setAttribute(SetAttribute, SetAttributeValue);
                            elem.click();
                        }
                        else
                        {
                            elem.setAttribute(SetAttribute, SetAttributeValue);
                        }
                        //elem.setAttribute(SetAttribute, SetAttributeValue);

                        //MessageBox.Show("SetAttribute : Setting");

                    }
                }
            }

        }

        public static string IE_Body_readHTML(string url)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString(url);

            return webData;
        }

        public static void IE_Tag_Action(string TagName, string GetAttribute, string GetAttributeValue, int act)
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
                        if (act == 0)
                        {
                            elem.click(); 
                        }

                        else if (act == 1)
                        {
                            HTMLInputButtonElement submitButton = (HTMLInputButtonElement)elem;
                            submitButton.disabled = false;
                        }
                        else if (act == 2)
                        {
                            HTMLInputButtonElement submitButton = (HTMLInputButtonElement)elem;
                            submitButton.disabled = true;
                        }
                        else if (act == 3)
                        {
                            var pwInput = (IHTMLElement2)elem;
                            pwInput.focus();
                        }
                        else if (act == 4)
                        {
                            var pwInput = (IHTMLElement2)elem;
                            pwInput.blur();
                        }
                        //else if (act == 5)
                        //{

                        //}
                        //else if (act == 6)
                        //{

                        //}
                        //else if (act == 7)
                        //{

                        //}
                        //else if (act == 8)
                        //{

                        //}
                        //else if (act == 9)
                        //{

                        //}
                        //else if (act == 10)
                        //{

                        //}
                        //else
                        {
                            ;
                        }
                    }
                }
            }

        }

        public static void IE_Navigate(string url)
        {
            ie.Navigate2(url);
        }

        public static string IE_Tagget_Collection(string TagName, string GetAttribute, string GetAttributeValue)
        {
            string val = "";
            mshtml.HTMLDocument doc = ie.Document;
            mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(TagName);
            string[] result = new string[0];
            foreach (mshtml.IHTMLElement elem in collection)
            {
                if (elem.getAttribute(GetAttribute) != null)
                {
                    string a = elem.getAttribute(GetAttribute);
                    //MessageBox.Show(a);

                    int t = result.Length;
                    Array.Resize(ref result, t + 1);
                    result[t] = a;
                }
            }


            val = Array_to_String(result);

            return val;
        }

        public static void IEQuit()
        {
            ie.Quit();
        }

        //public string[] String_to_Array(string String_data)
        //{
        //    string[] Array_Result = new string[0];
        //    int size = String_split_newLine(String_data, ":::").Length;
        //    Array.Resize(ref Array_Result, size);
        //    Array_Result = String_split_newLine(String_data, ":::");
        //    return Array_Result;
        //}

        public static string Array_to_String(string[] Array_data)
        {
            string String_Result = "";
            int i = 0;
            foreach (string data in Array_data)
            {
                if (i == 0)
                {
                    String_Result = data;
                    i = 2;
                }
                else
                {
                    String_Result = String_Result + ":::" + data;
                }
            }
            return String_Result;
        }

        public static string IE_Get_Text(string link)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string input = wc.DownloadString(link);
            string results = GetPlainTextFromHtml(input);


            //System.Windows.MessageBox.Show(input);
            //string delimeter1 = "\n"; 
            //string[] result = new string[0];
            //string results = "";
            //string[] filter1 = input.Split(new string[] { delimeter1 }, StringSplitOptions.None); 
            //foreach (string s in filter1)
            //{
            //    if (s.Contains(">") && s.Contains("</"))
            //    {
            //        int pFrom = s.IndexOf(">") + "</".Length;
            //        int pTo = s.LastIndexOf(s);

            //        if (pTo > pFrom)
            //        {
            //            results = results + s.Substring(pFrom, pTo - pFrom);
            //        }
            //    }
            //    else if (s.Contains(">"))
            //    {
            //            int pFrom = s.IndexOf(">");
            //            int pTo = s.LastIndexOf(s);
            //        if (pTo > pFrom)
            //        {
            //            results = results + s.Substring(pFrom, pTo - pFrom);
            //        }


            //    }

            //}
            //System.Windows.MessageBox.Show(results);
            return results;

        }

        public static string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }

        public static string HTMLToText(string HTMLCode)
        {
            HTMLCode = HTMLCode.Replace("\n", " ");
            HTMLCode = HTMLCode.Replace("\t", " ");
            HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");
            HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
              , RegexOptions.IgnoreCase | RegexOptions.Singleline);

            StringBuilder sbHTML = new StringBuilder(HTMLCode);
            string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
   "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
            string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
            for (int i = 0; i < OldWords.Length; i++)
            {
                sbHTML.Replace(OldWords[i], NewWords[i]);
            }

            sbHTML.Replace("<br>", "\n<br>");
            sbHTML.Replace("<br ", "\n<br ");
            sbHTML.Replace("<p ", "\n<p ");

            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        public static string[] DataScrapByTag_Attribute(string tagName, string attribute, string filterAttribute, string filterAttributeValue)
        {
            string[] Data = new string[0];
            int i = 0;
            bool filter = false;
            mshtml.HTMLDocument doc = ie.Document;
            if(string.IsNullOrEmpty(filterAttribute)&& string.IsNullOrEmpty(filterAttributeValue))
            {
                filter = false;
            }
            else
            {
                filter = true;
            }

            mshtml.IHTMLElementCollection collection = doc.getElementsByTagName(tagName);
            //MessageBox.Show("TagName : " + TagName);
            foreach (mshtml.IHTMLElement elem in collection)
            {
                if (elem.getAttribute(attribute) != null)
                {
                    if(filter == false)
                    {

                        try
                        {

                            string a = elem.getAttribute(attribute);

                            if (a.Length > 0)
                            {
                                int array_Len = Data.Length + 1;
                                Array.Resize(ref Data, array_Len);
                                Data[i] = a;
                                i++;
                            }
                        }
                        catch
                        {
                            ;
                        }
                    }
                    else if(filter == true)
                    {

                        try
                        {
                            if (elem.getAttribute(filterAttribute).Equals(filterAttributeValue))
                            {
                                string a = elem.getAttribute(attribute);

                                if (a.Length > 0)
                                {
                                    int array_Len = Data.Length + 1;
                                    Array.Resize(ref Data, array_Len);
                                    Data[i] = a;
                                    i++;
                                }
                            }
                        }
                        catch
                        {
                            ;
                        }

                    }

                }
            }
            return Data;
        }

        public static string[] FrameDataScrapByTag_Attribute(string tagName, string attribute, string filterAttribute, string filterAttributeValue)
        {
            mshtml.HTMLDocument doc = ie.Document;
            string[] Data = new string[0];
            int i = 0;
            bool filter = false;
            if (string.IsNullOrEmpty(filterAttribute) && string.IsNullOrEmpty(filterAttributeValue))
            {
                filter = false;
            }
            else
            {
                filter = true;
            }
            IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
            foreach (IHTMLElement iel in allFrames)
            {
                
                HTMLFrameElement frm = (HTMLFrameElement)iel;
                DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;
                mshtml.IHTMLElementCollection collection = doc1.getElementsByTagName(tagName);
                //MessageBox.Show("TagName : " + TagName);
                foreach (mshtml.IHTMLElement elem in collection)
                {
                    if (elem.getAttribute(attribute) != null)
                    {
                        if (filter == false)
                        {

                            try
                            {

                                string a = elem.getAttribute(attribute);

                                if (a.Length > 0)
                                {
                                    int array_Len = Data.Length + 1;
                                    Array.Resize(ref Data, array_Len);
                                    Data[i] = a;
                                    i++;
                                }
                            }
                            catch
                            {
                                ;
                            }
                        }
                        else if (filter == true)
                        {

                            try
                            {
                                if (elem.getAttribute(filterAttribute).Equals(filterAttributeValue))
                                {
                                    string a = elem.getAttribute(attribute);

                                    if (a.Length > 0)
                                    {
                                        int array_Len = Data.Length + 1;
                                        Array.Resize(ref Data, array_Len);
                                        Data[i] = a;
                                        i++;
                                    }
                                }
                            }
                            catch
                            {
                                ;
                            }

                        }

                    }
                }
                
            }
            return Data;
        }

        public static void IFrame_Tag_Element(string TagName, string GetAttribute, string GetAttributeValue, string SetAttribute, string SetAttributeValue)
        {
            mshtml.HTMLDocument doc = ie.Document;

            IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
            foreach (IHTMLElement iel in allFrames)
            {

                HTMLFrameElement frm = (HTMLFrameElement)iel;
                DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;

                mshtml.IHTMLElementCollection collection = doc1.getElementsByTagName(TagName);

                
                //MessageBox.Show("TagName : " + TagName);
                foreach (mshtml.IHTMLElement elem in collection)
                {
                    if (elem.getAttribute(GetAttribute) != null)
                    {

                        //try
                        //{
                        //    string a = elem.getAttribute(GetAttribute);
                        //}
                        //catch
                        //{
                        //    ;
                        //}
                        //MessageBox.Show("GetAttribute : Not null");
                        if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
                        {
                            if(TagName == "combobox" || TagName == "select")
                            {
                                //elem.setAttribute(SetAttribute, SetAttributeValue);
                                HTMLSelectElement a1 = (HTMLSelectElement)elem;
                                a1.setAttribute(SetAttribute, SetAttributeValue);
                                a1.FireEvent("onchange");
                            }
                            else
                            {
                                elem.setAttribute(SetAttribute, SetAttributeValue);
                            }
                            //elem.setAttribute(SetAttribute, SetAttributeValue);

                            //MessageBox.Show("SetAttribute : Setting");

                        }
                    }
                }
            }

        }

        public static void IFrame_Tag_Action(string TagName, string GetAttribute, string GetAttributeValue, int act)
        {
            mshtml.HTMLDocument doc = ie.Document;

            IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
            foreach (IHTMLElement iel in allFrames)
            {
                HTMLFrameElement frm = (HTMLFrameElement)iel;
                DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;

                mshtml.IHTMLElementCollection collection = doc1.getElementsByTagName(TagName);

                //MessageBox.Show("TagName : " + TagName);
                foreach (mshtml.IHTMLElement elem in collection)
                {
                    if (elem.getAttribute(GetAttribute) != null)
                    {
                        //MessageBox.Show("GetAttribute : Not null");
                        if (elem.getAttribute(GetAttribute).Equals(GetAttributeValue))
                        {
                            if (act == 0)
                            {
                                elem.click();
                            }

                            else if (act == 1)
                            {
                                HTMLInputButtonElement submitButton = (HTMLInputButtonElement)elem;
                                submitButton.disabled = false;
                                
                            }
                            else if (act == 2)
                            {
                                HTMLInputButtonElement submitButton = (HTMLInputButtonElement)elem;
                                submitButton.disabled = true;
                            }
                            else if (act == 3)
                            {
                                var pwInput = (IHTMLElement2)elem;
                                pwInput.focus();
                            }
                            else if (act == 4)
                            {
                                var pwInput = (IHTMLElement2)elem;
                                pwInput.blur();
                            }
                            //else if (act == 5)
                            //{

                            //}
                            //else if (act == 6)
                            //{

                            //}
                            //else if (act == 7)
                            //{

                            //}
                            //else if (act == 8)
                            //{

                            //}
                            //else if (act == 9)
                            //{

                            //}
                            //else if (act == 10)
                            //{

                            //}
                            //else
                            {
                                ;
                            }
                        }
                    }
                }
            }

        }

        public static void HTMLTable()
        {
            mshtml.HTMLDocument doc = ie.Document;
            IHTMLElementCollection tables = doc.getElementsByTagName("table"); 
            foreach(IHTMLElement tbl in tables)
            {
                string a = tbl.innerText;
            }
        }

        public static void SelectBox(string id, string value, string FrameName)
        {
            bool Frame = false;
            if(string.IsNullOrEmpty(FrameName) == true)
            {
                Frame = false;
            }
            else
            {
                Frame = true;
            }
            if(Frame == false)
            {
                mshtml.HTMLDocument doc = ie.Document;
                var select = doc.getElementById(id);

                mshtml.HTMLSelectElement cbProyectos = select as mshtml.HTMLSelectElement;

                var total = cbProyectos.length;
                for (var i = 0; i < total; i++)
                {
                    cbProyectos.selectedIndex = i;
                    if (cbProyectos.value.Contains(id))
                    {
                        break;
                    }

                }
                //cbProyectos.selectedIndex = 4;
                select.onselectstart.InvokeMember("onchange");

                select.children.Children[4].SetAttribute("selected", "selected");

                var theElementCollection = ie.Document.GetElementsByTagName("select");
                foreach (HtmlElement el in theElementCollection)
                {
                    if (el.GetAttribute("value").Equals(id))
                    {
                        el.SetAttribute("selected", "selected");
                        //el.InvokeMember("click");
                    }
                }
            }
            else if(Frame == true)
            {
                mshtml.HTMLDocument doc = ie.Document;

                IHTMLElementCollection allFrames = doc.getElementsByTagName("iframe");
                foreach (IHTMLElement iel in allFrames)
                {
                    string a = iel.getAttribute("name");
                    HTMLFrameElement frm = (HTMLFrameElement)iel;
                    DispHTMLDocument doc1 = (DispHTMLDocument)((SHDocVw.IWebBrowser2)frm).Document;
                    var select = doc1.getElementById(id);

                    mshtml.HTMLSelectElement cbProyectos = select as mshtml.HTMLSelectElement;

                    var total = cbProyectos.length;
                    for (var i = 0; i < total; i++)
                    {
                        cbProyectos.selectedIndex = i;
                        if (cbProyectos.value.Contains(id))
                        {
                            break;
                        }

                    }
                    //cbProyectos.selectedIndex = 4;
                    select.click();

                    //select.children.Children[4].SetAttribute("selected", "selected");

                    var theElementCollection = doc1.getElementsByTagName("select");
                    foreach (IHTMLElement el in theElementCollection)
                    {
                        if (el.getAttribute("value").Equals(id))
                        {
                            el.setAttribute("selected", "selected");
                            //el.InvokeMember("click");
                        }
                    }

                }
            }
            
        }
        public static void SelectBox(string SelectBoxTagName, int OptionIndex, bool InFrame = false)
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
