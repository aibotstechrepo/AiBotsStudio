using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace String_Operation
{
    public static class StringOperations
    {
        public static class StringActivities
        {
            /// <summary>
            /// Function to check if a given string is alpha,numeric,alphanumeric or not
            /// </summary>
            /// <param name="text">The string to check</param>
            /// <param name="IsAlpha">Flag to check if string contains alphabets</param>
            /// <param name="IsNumber">Flag to check if string contains numbers</param>
            /// <returns>True/False</returns>
            public static bool StringAlphaNumeric(string text, bool IsAlpha, bool IsNumber)
            {
                bool data = false;
                if (IsAlpha == false && IsNumber == false)
                {
                    data = text.All(char.IsLetterOrDigit);
                }
                else if (IsAlpha == true && IsNumber == false)
                {
                    data = text.All(char.IsLetter);
                }
                else if (IsAlpha == false && IsNumber == true)
                {
                    data = text.All(char.IsDigit);
                }
                else if (IsAlpha == true && IsNumber == true)
                {
                    data = text.All(char.IsLetterOrDigit);
                }
                else
                {
                    data = false;
                }
                return data;
            }

            /// <summary>
            /// Function to convert ascii value to equivalent character value
            /// </summary>
            /// <param name="Ascii_Val">Ascii value of type int</param>
            /// <returns>Char value of Ascii value</returns>
            public static char StringAsciiToChar(int Ascii_Val)
            {
                char ch = Convert.ToChar(Ascii_Val);
                return ch;
            }

            /// <summary>
            /// Function to retrieve substring between start and end position of main string
            /// </summary>
            /// <param name="Text">Main string from which substring(s) is to be extracted</param>
            /// <param name="From">Start string of substring</param>
            /// <param name="To">End string of substring</param>
            /// <returns>String array containing 1 or more outputs</returns>
            public static string[] StringBetween(string Text, string From, String To)
            {
                string[] data = new string[0];
                if (From == To)
                {
                    #region method 1
                    int i = 0;
                    bool flag = false;
                    string subText = Text;
                    int pFrom = 0;
                    int pTo = 0;
                    while (subText.Contains(From) && subText.Contains(To))
                    {
                        if (From != To)
                        {
                            pFrom = subText.IndexOf(From) + From.Length;
                            pTo = subText.IndexOf(To);
                            if (subText.Contains(From) && subText.Contains(To))
                            {
                                if (pFrom < pTo)
                                {
                                    Array.Resize(ref data, data.Length + 1);
                                    data[i] = subText.Substring(pFrom, pTo - pFrom);
                                    subText = subText.Substring(pTo + 1, subText.Length - pTo - 1);
                                    i++;

                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (From == To)
                        {
                            flag = true;
                            break;
                        }
                        else
                            break;
                    }
                    if (flag == true)
                    {
                        int pf = Text.IndexOf(From) + From.Length;
                        int pt = Text.IndexOf(To, pf);
                        string[] data1 = new string[0];
                        int i1 = 0;
                        while (pt != -1 && pf != -1)
                        {
                            Array.Resize(ref data, data.Length + 1);
                            data[i1] = Text.Substring(pf, pt - pf);
                            i1++;
                            pf = Text.IndexOf(From, pt) + From.Length;
                            if (pf >= Text.Length) break;
                            pt = Text.IndexOf(To, pf);
                        }
                    }

                    #endregion
                    return data;
                }
                else
                {
                    string[] data1 = datafunction1(Text, From, To);
                    return data1;
                }
            }

            /// <summary>
            /// Function to convert character value into equivalent ascii value
            /// </summary>
            /// <param name="CharacterValue">Chartacter value of type char</param>
            /// <returns>Integer Ascii value of character</returns>
            public static int StringCharToAscii(char CharacterValue)
            {
                int asciiBytes = (int)CharacterValue;
                return asciiBytes;
            }

            /// <summary>
            /// Function to compare two string to check if they are equal or not
            /// </summary>
            /// <param name="Text1">String 1</param>
            /// <param name="Text2">String 2</param>
            /// <param name="Case">Ignore case True/False</param>
            /// <returns>True/False</returns>
            public static bool StringCompare(string Text1, string Text2, bool Case)
            {
                if (Case == true)
                {
                    int a = string.Compare(Text1, Text2, false);
                    if (a == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    int a = string.Compare(Text1, Text2, true);
                    if (a == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            /// <summary>
            /// Function to retrieve the index of substring in main string
            /// </summary>
            /// <param name="Text">Main string</param>
            /// <param name="Subtext">Substring to retrieve from main string</param>
            /// <param name="Case">Ignore case True/False</param>
            /// <returns>Position of substring in main string</returns>
            public static int String_In_String(string Text, string Subtext, bool Case)
            {
                int pos = -1;
                if (Text.Contains(Subtext) == true)
                {

                    if (Case == true)
                    {
                        pos = Text.IndexOf(Subtext, StringComparison.CurrentCulture);
                    }
                    else
                    {
                        pos = Text.IndexOf(Subtext, StringComparison.CurrentCultureIgnoreCase);
                    }
                    return pos;
                }
                else
                {
                    return 0;
                }
            }

            /// <summary>
            /// Function to extract substring from left upto count
            /// </summary>
            /// <param name="Text">Main string</param>
            /// <param name="count">Number of characters to extract</param>
            /// <returns>Substring obtained from extracting from position 0 to count </returns>
            public static string StringLeft(string Text, int count)
            {
                string stringLeft;
                if (Text.Length >= count)
                {
                    stringLeft = Text.Substring(0, count);
                    return stringLeft;
                }
                else
                {
                    stringLeft = Text.Substring(0, Text.Length);
                    return stringLeft;
                }
            }

            /// <summary>
            /// Function to get length of given string
            /// </summary>
            /// <param name="Text">Main string</param>
            /// <returns>Length of the string</returns>
            public static int StringLength(string Text)
            {
                int length = Text.Length;
                return length;
            }

            /// <summary>
            /// Function to extract substring from position to specified count
            /// </summary>
            /// <param name="Text">Main String</param>
            /// <param name="pos">Starting position from where extraction should take place</param>
            /// <param name="count">Number of characters to extract</param>
            /// <returns>Substring obtained from main string</returns>
            public static string StringMid(string Text, int pos, int count)
            {
                string stringMid;
                if (count + pos - 1 >= Text.Length)
                {
                    if (pos - 1 >= Text.Length)
                    {
                        stringMid = "";
                    }
                    else stringMid = Text.Substring(pos - 1, Text.Length - pos + 1);
                }
                else
                {
                    stringMid = Text.Substring(pos - 1, count + 1);
                }
                return stringMid;
            }

            /// <summary>
            /// Function to replace substring with new string in a main string
            /// </summary>
            /// <param name="Text">Main String</param>
            /// <param name="TextToFind">Text To Find</param>
            /// <param name="ReplaceText">Rplace String</param>
            /// <param name="Case">Ignore Case True/False</param>
            /// <returns>Updated String after replace</returns>
            public static string StringReplace(string Text, string TextToFind, string ReplaceText, bool Case)
            {
                string newval;
                if (Case == false)
                {
                    newval = Regex.Replace(Text, TextToFind, ReplaceText, RegexOptions.IgnoreCase);
                }
                else
                {
                    newval = Text.Replace(TextToFind, ReplaceText);
                }
                return newval;
            }

            /// <summary>
            /// Function to extract string from position to end
            /// </summary>
            /// <param name="Text">Main String</param>
            /// <param name="count">Position to extract from</param>
            /// <returns>Substring obtained from main string</returns>
            public static string StringRight(string Text, int count)
            {
                int lastString = Text.Length;
                if (count <= lastString)
                {
                    string stringRight = Text.Substring(lastString - count);
                    return stringRight;
                }
                else
                {
                    return Text;
                }
            }

            /// <summary>
            /// Function to get the Ascii value of each charcter of a string
            /// </summary>
            /// <param name="charVal">Input String</param>
            /// <returns>Int Array of Ascii Values</returns>
            public static int[] StringToAscii(string charVal)
            {
                int i = 0;
                int[] res = new int[0];
                foreach (char c in charVal)
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[i] = System.Convert.ToInt32(c);
                    i++;
                }
                return res;
            }

            /// <summary>
            /// Function to remove character from a given string
            /// </summary>
            /// <param name="Text">Main String</param>
            /// <param name="size">number of characters to remove</param>
            /// <param name="Direction">Left/Right</param>
            /// <returns></returns>
            public static string StringTrimCharacter(string Text, int size, string Direction)
            {
                string outVal = "";
                if (Text.Length < size)
                {
                    return "";
                }
                else if (Direction.ToLower() == "right")
                {
                    outVal = Text.Substring(0, Text.Length - size);
                    return outVal;
                }
                else if (Direction.ToLower() == "left") //trim Left and new
                {
                    outVal = Text.Substring(size, Text.Length - size);
                    return outVal;
                }
                else
                {
                    return Text;
                }
            }

            /// <summary>
            /// Function to remove whitespaces from main string
            /// </summary>
            /// <param name="Text">Main String</param>
            /// <param name="Trim_Left">From Left (Boolean)</param>
            /// <param name="Trim_Right">From Right (Boolean)</param>
            /// <returns></returns>
            public static string StringTrimWhiteSpace(string Text, bool Trim_Left, bool Trim_Right)
            {
                string outVal = "";
                if (Trim_Left == true && Trim_Right == false)
                {
                    outVal = Text.TrimStart();
                }
                else if (Trim_Right == true && Trim_Left == false)
                {
                    outVal = Text.TrimEnd();
                }
                else if (Trim_Right == false && Trim_Left == false)
                {
                    outVal = Text.Trim();
                }
                else
                {
                    outVal = Text.Trim();
                }
                return outVal;
            }
            /// <summary>
            /// Function to extract only numbers in given string. Ex: Input: A_00$@#6  Output:006
            /// </summary>
            /// <param name="data">String to extract number</param>
            /// <returns></returns>
            public static int ExtractNumbers(string data)
            {
                try
                {

                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        string numeric = new String(data.Where(Char.IsDigit).ToArray());
                        return Convert.ToInt32(numeric);
                    }
                }
                catch
                {
                    ;
                }
                return -1;
            }

            /// <summary>
            /// Function to extract only Characters in given string. Ex: Input:  A_00$@#6  Output:A
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public static string ExtractCharacters(string data)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        data = new String(data.Where(c => Char.IsLetter(c)).ToArray());
                        return data;
                    }
                }
                catch
                {
                    ;
                }
                return null;
            }
            #region method 3
            public static string[] datafunction1(string source, string start, string end)
            {
                string[] datas = new string[0];
                int i = 0;
                string pattern = string.Format("{0}({1}){2}", Regex.Escape(start), "(.+?)", Regex.Escape(end));

                foreach (Match m in Regex.Matches(source, pattern))
                {
                    Array.Resize(ref datas, datas.Length + 1);
                    datas[i] = m.Groups[1].Value;
                    i++;
                }
                return datas;
            }
            #endregion
        }
    }
}
