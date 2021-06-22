using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace String_Operation
{

    public sealed class String_Between : CodeActivity
    {
        [Category("Input")]
        [DisplayName("Source Text")] 
        [RequiredArgument]
        public InArgument<string> Text { get; set; }

        [Category("Input")]
        [DisplayName("Search from")]
        [RequiredArgument]
        public InArgument<string> From { get; set; }

        [Category("Input")]
        [DisplayName("Search to")]
        [RequiredArgument]
        public InArgument<string> To { get; set; }


        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        [Category("Output")]
        [DisplayName("Found Text")]
        public OutArgument<string[]> Text_Found { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            //try
            //{
                string text = context.GetValue(this.Text);
            string from = context.GetValue(this.From);
            //    //string from = "E";
            string to = context.GetValue(this.To);
                //string[] data = datafunction(text, from, to);
                //    //string to = "O";
                string[] data = new string[0];
                if(from==to)
                {
                      
                #region method 1
                int i = 0;
                bool flag = false;
                string subText = text;
                int pFrom = 0;
                int pTo = 0;
                while (subText.Contains(from) && subText.Contains(to))
                {
                    if (from != to)
                    {
                        pFrom = subText.IndexOf(from) + from.Length;
                        pTo = subText.IndexOf(to);
                        if (subText.Contains(from) && subText.Contains(to))
                        {
                            if (pFrom < pTo)
                            {
                                Array.Resize(ref data, data.Length + 1);
                                data[i] = subText.Substring(pFrom, pTo - pFrom);
                                subText = subText.Substring(pTo + 1, subText.Length - pTo - 1);
                                //System.Windows.MessageBox.Show(data[i]);
                                //System.Windows.MessageBox.Show(subText);
                                i++;

                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (from == to)
                    {
                        flag = true;
                        break;

                        //if (subText.Contains(from) && subText.Contains(to))
                        //{

                        //    if (from.Length >= subText.Length || to.Length >= subText.Length)
                        //    {
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        pFrom = subText.IndexOf(from) + from.Length;
                        //        try
                        //        {
                        //            pTo = subText.IndexOf(to, pFrom);
                        //        }
                        //        catch
                        //        {
                        //            break;
                        //        }

                        //    }
                        //    if (pFrom < pTo)
                        //    {
                        //        Array.Resize(ref data, data.Length + 1);
                        //        data[i] = subText.Substring(pFrom, pTo - pFrom);
                        //        subText = subText.Substring(pTo, subText.Length - pTo);
                        //        //System.Windows.MessageBox.Show(data[i]);
                        //        //System.Windows.MessageBox.Show(subText);
                        //        i++;

                        //    }
                        //    else if(pFrom==pTo)
                        //    {
                        //        Array.Resize(ref data, data.Length + 1);
                        //        data[i] = "";
                        //        i++;
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }
                        //}
                    }
                    else
                        break;
                }
                if(flag==true)
                {
                  //  string text = "hhtps://www.gmail.com.hpo/hp/www/rrr/"; string from = "/"; string to = "/";
                    int pf = text.IndexOf(from) + from.Length;
                    int pt = text.IndexOf(to, pf);
                    string[] data1 = new string[0];
                    int i1 = 0;
                    while (pt != -1 && pf != -1)
                    {
                        Array.Resize(ref data, data.Length + 1);
                        data[i1] = text.Substring(pf, pt - pf);
                        i1++;
                        pf = text.IndexOf(from, pt) + from.Length;
                        if (pf >= text.Length) break;
                        pt = text.IndexOf(to, pf);
                    }
                }



                    //else if ((pFrom == pTo) || (pTo < pFrom))
                    //{
                    //    if (subText.Length < pTo + 1) break;
                    //    else if (subText.Length > pTo + 1)
                    //    {

                    //        string aa = subText.Substring(pTo+1, subText.Length - pTo);
                    //        pTo = aa.IndexOf(to)+1;
                    //        goto Loop;
                    //    }
                    //    else
                    //    {
                    //        subText = subText.Substring(pTo + 1, subText.Length - pTo - 1);
                    //        goto Loop;
                    //    }

                    //}





                

                //System.Windows.MessageBox.Show(subText);
                //System.Windows.MessageBox.Show("while");

            #endregion
                Text_Found.Set(context, data);
                Result.Set(context, true);
                }
                else
                {
                    string[] data1 = datafunction1(text, from, to);
                    Text_Found.Set(context, data1);
                    Result.Set(context, true);
                }
            //}

            //catch
            //{
            //    string[] data1 = new string[0];

            //    Text_Found.Set(context, data1);
            //    Result.Set(context, false);
            //}

            #region string logic
            //int pFrom = text.IndexOf(from) + from.Length;
            //int pTo = text.IndexOf(to);

            //string result = text.Substring(pFrom, pTo - pFrom);
            #endregion

            #region method 2

            //string between = text.Substring(from, to);
            //Text_Found.Set(context, between);
            #endregion

        }
        #region method 3
            private string[] datafunction1(string source, string start, string end)
            {
                string[] datas = new string[0];
                int i = 0;
                string pattern = string.Format("{0}({1}){2}", Regex.Escape(start),"(.+?)",Regex.Escape(end));

            foreach (Match m in Regex.Matches(source, pattern))
                {
                    Array.Resize(ref datas, datas.Length + 1);
                    datas[i] =m.Groups[1].Value;
                    i++;
                }
                return datas;
                
            }
         #endregion
        #region method 4 
        private string[] datafunction2(string body, string start, string end)
        {
            string[] matched = new string[0];
            int indexStart = 0;
            int indexEnd = 0;
            int i = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = body.IndexOf(start);

                if (indexStart != -1)
                {
                    indexEnd = indexStart + body.Substring(indexStart).IndexOf(end);
                    Array.Resize(ref matched, matched.Length + 1);
                    matched[i]=(body.Substring(indexStart + start.Length, indexEnd - indexStart - start.Length));

                    body = body.Substring(indexEnd + end.Length);
                    i++;
                }
                else
                {
                    exit = true;
                }
            }

            return matched;
        }
        #endregion

       
 

    }

    #region mothod 2 class
    //public static class StringExtensions
    //{
    //    public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
    //    {
    //        var fromLength = (from ?? string.Empty).Length;
    //        var startIndex = !string.IsNullOrEmpty(from)
    //            ? @this.IndexOf(from, comparison) + fromLength
    //            : 0;

    //        if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

    //        var endIndex = !string.IsNullOrEmpty(until)
    //        ? @this.IndexOf(until, startIndex, comparison)
    //        : @this.Length;

    //        if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

    //        var subString = @this.Substring(startIndex, endIndex - startIndex);
    //        return subString;
    //    }


    //}
    #endregion
    // usage: 

}
