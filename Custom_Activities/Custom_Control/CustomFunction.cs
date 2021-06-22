using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;



using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace Custom_Control
{
    public class CustomFunction
    {
        
        string[] dataset = new string[10];
        
        
        public string File_List_Array(string Location, string ft)
        {
            string file_Location = Location;
            //string[] array1 = Directory.GetFiles(@"E:\");
            string[] array1 = Directory.GetFiles(@"" + file_Location);
            string temp = "";
            //string File_Type = ".pdf";
            string File_Type = "";
            string[] File_List = new string[0];
            //System.Windows.Forms.MessageBox.Show("in fun total files" + array1.Length.ToString());
            //System.Windows.Forms.MessageBox.Show("iFile_Type size" + File_Type.Length.ToString());
            

            if (File_Type.Length > 2)
            {
                foreach (string name in array1)
                {
                    if (name.Contains(File_Type) == true)
                    {
                        //temp = temp + name + ";";
                        int t = File_List.Length;
                        //System.Windows.Forms.MessageBox.Show("size before" + t.ToString());
                       // System.Windows.Forms.MessageBox.Show("size before" + File_List.Length.ToString());
                        Array.Resize(ref File_List, t + 1);
                        //System.Windows.Forms.MessageBox.Show("size after" + File_List.Length.ToString());

                       // System.Windows.Forms.MessageBox.Show("size before" + t.ToString());
                        File_List[t] = name;
                       // System.Windows.Forms.MessageBox.Show("array data" + File_List[t]);
                    }
                   // System.Windows.Forms.MessageBox.Show(name);
                }
            }
            else
            {
                foreach (string name in array1)
                {
                    temp = temp + name + ";";

                    int t = File_List.Length;
                    Array.Resize(ref File_List, t + 1);
                    File_List[t] = name;
                   //System.Windows.Forms.MessageBox.Show(name);
                }
            }
            //}
            //int o = 1;
            //foreach (string name in File_List)
            //{
                
            //    System.Windows.Forms.MessageBox.Show(o + " : " + name);
            //    o++;
            //}

            string File_List_string = Array_to_String(File_List);

            return File_List_string;
        }
        
        public void datapush(string a)
        {
            dataset[0] = a;
        }

        public string dataread()
        {
            string a = dataset[0];
            return a;
        }
        public void Open_File(string File_Location)
        {
            System.Diagnostics.Process.Start(@"" + File_Location);
            Thread.Sleep(3000);
            SendKeys.Send("{DOWN}");
            Thread.Sleep(3000);
        }
        public void invoice_pdf(string File_Location)
        {

            System.Diagnostics.Process.Start(@"" + File_Location);
            Thread.Sleep(3000);
            SendKeys.Send("{DOWN}");
            Thread.Sleep(3000);
        }
        public void Close_Window(string strWinTitle)
        {
            #region sample
            //var myFile = File.Create(@""+file);
            //myFile.Close();

            //bool blnReturn = false;
            //System.IO.FileStream fs;
            //try
            //{
            //    fs = System.IO.File.Open(@""+strFullFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, System.IO.FileShare.None);
            //    fs.Close();
            //}
            //catch (System.IO.IOException ex)
            //{
            //    blnReturn = true;
            //}
            //return blnReturn;
            #endregion

            SwitchToWinows(strWinTitle);
            Thread.Sleep(1000);
            //MessageBox.Show("close now");
            SendKeys.SendWait("%{F4}");
        }

        public string String_Operation_Left(string stringtext, int count)
        {
            string stringLef = stringtext.Substring(0, count);
            return stringLef;
        }
        public string String_Operation_Right(string stringtext, int count)
        {          
            int lastString = Convert.ToInt32(stringtext.Length);
            string stringRht = stringtext.Substring(lastString - count);
            //MessageBox.Show(stringRht);
            return stringRht;
        }
        public string String_Operation_Middle(string stringtext, int Position, int count)
        { 
            string stringMid = stringtext.Substring(Position, count);
            //MessageBox.Show(stringMid);
            return stringMid;
        }
        public bool String_operation_Match(string stringtext, string substring)
        {
            bool found = false;
            if (stringtext.Contains(substring))
            {
                //MessageBox.Show("String Found");
                return found = true;
            }
            else
            {
                //MessageBox.Show("String not Found");
                return found = false;
            }
        }

        

        public string[] String_split_newLine(string data,string delimiter)
        {
            string input = data;
            string delimeter1 = "\n";
            string delimeter2 = delimiter;
            string[] result = new string[0];
            string[] filter1 = input.Split(new string[] { delimeter1 }, StringSplitOptions.None);
            bool flag = false;
            foreach (string s in filter1)
            {
                //MessageBox.Show("Delim 1 : -" + s);
                if (delimeter2.Length > 2)
                {
                    string[] result1 = s.Split(new string[] { delimeter2 }, StringSplitOptions.None);
                    foreach (string s1 in result1)
                    {
                       // MessageBox.Show("Delim 2 : -" + s1);
                        int t = result.Length;
                        Array.Resize(ref result, t + 1);
                        result[t] = s1;
                    }
                    flag = true; 
                }
                else
                {
                    flag = false;
                }
            }
            if(flag == true)
            {
                return result;
            }
            else
            {
                return filter1;
            }
        }
        public void copy_all()
        {
            SendKeys.SendWait("^a");
            Thread.Sleep(1000);
            SendKeys.SendWait("^c");
            //System.Windows.Forms.MessageBox.Show("copied");
        }

        //public void Excel_Write_Cell(string Filepath, string Filename, string rangeFrom, string[,] data,bool Visibility)
        public void Excel_Write_Cell(string Filepath, string Filename, string[,] data,bool Visibility)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                if (Visibility == true)
                {
                    oXL.Visible = true;
                }
                if(Visibility == false)
                {
                    oXL.Visible = false;
                }
                

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
                


                int row_pos = data.GetLength(0);
                int Column_pos = data.GetLength(1);
                //System.Windows.Forms.MessageBox.Show("no.of rows : " + row_pos.ToString());
                //System.Windows.Forms.MessageBox.Show("no.of col : " + Column_pos.ToString());

                //oSheet.Cells[1, 1] = "First Name";
                //oSheet.Cells[1, 2] = "Last Name";
                //oSheet.Cells[1, 3] = "Full Name";
                //oSheet.Cells[1, 4] = "Salary";

                for (int i = 0; i < row_pos; i++)
                {
                    for (int j = 0; j < Column_pos; j++)
                    {
                        if (i == 0)
                        {
                            oSheet.Cells[i +1, j + 1] = data[i, j];
                            oSheet.get_Range("A1","F1").Font.Bold = true;
                            oSheet.get_Range("A1", "F1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                            //Thread.Sleep(2000);

                        }
                        else
                        {
                            oSheet.Cells[i + 1, j + 1] = data[i, j];
                            //Thread.Sleep(2000);
                        }
                    }
                    
                }
                
                oSheet.Cells[1, 6] = "Upload_Status";
                oSheet.Cells[2, 6] = "Success";
                oSheet.Cells[3, 6] = "Success";
                oSheet.Cells[4, 6] = "Success";
                oSheet.Cells[5, 6] = "Success";
                oSheet.Cells[6, 6] = "Review Requiered";

                oRng = oSheet.get_Range("A1", "F1");
                oRng.EntireColumn.AutoFit();
                Thread.Sleep(3000);

                #region test 
                ////Add table headers going cell by cell.
                //oSheet.Cells[1, 1] = "First Name";
                //oSheet.Cells[1, 2] = "Last Name";
                //oSheet.Cells[1, 3] = "Full Name";
                //oSheet.Cells[1, 4] = "Salary";

                ////Format A1:D1 as bold, vertical alignment = center.
                //oSheet.get_Range("A1", "D1").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment =
                //    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                //// Create an array to multiple values at once.
                //string[,] saNames = new string[5, 2];

                //saNames[0, 0] = "John";
                //saNames[0, 1] = "Smith";
                //saNames[1, 0] = "Tom";

                //saNames[4, 1] = "Johnson";

                ////Fill A2:B6 with an array of values (First and Last Names).
                //oSheet.get_Range("A2", "B6").Value2 = saNames;

                ////Fill C2:C6 with a relative formula (=A2 & " " & B2).
                //oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";

                ////Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                //oRng = oSheet.get_Range("A1", "D1");
                //oRng.EntireColumn.AutoFit();
                #endregion

                oXL.Visible = false;
                oXL.UserControl = false;
                //oWB.SaveAs("e:\\test505.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                //    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.SaveAs(Filepath + @"\"+ Filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();

                //...
            }
            catch
            {
                ;
            }
        }

        public string PheniexOCR(string filename)
        {
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
            //System.Windows.Forms.MessageBox.Show(text1.ToString());
            return text1.ToString();
        }

        public string[] String_to_Array(string String_data)
        {
            string[] Array_Result = new string[0];
            int size = String_split_newLine(String_data, ":::").Length;
            Array.Resize(ref Array_Result, size);
            Array_Result = String_split_newLine(String_data, ":::");
            return Array_Result;
        }
        public string Array_to_String(string[] Array_data)
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
        //public void 

        #region Find Window - Mian Logic

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(Win32Callback enumProc, IntPtr lParam);

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            List<IntPtr> pointers = GCHandle.FromIntPtr(pointer).Target as List<IntPtr>;
            pointers.Add(handle);
            return true;
        }

        private static List<IntPtr> GetAllWindows()
        {
            Win32Callback enumCallback = new Win32Callback(EnumWindow);
            List<IntPtr> AllWindowPtrs = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(AllWindowPtrs);
            try
            {
                EnumWindows(enumCallback, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return AllWindowPtrs;
        }

        [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr windowHandle, StringBuilder stringBuilder, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true)]
        internal static extern int GetWindowTextLength(IntPtr hwnd);
        private static string GetTitle(IntPtr handle)
        {
            int length = GetWindowTextLength(handle);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(handle, sb, sb.Capacity);
            return sb.ToString();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        private static void SwitchToWinows(string text)
        {
            List<IntPtr> AllWindowsPtrs = GetAllWindows();
            foreach (IntPtr ThisWindowPtr in AllWindowsPtrs)
            {
                //if (GetTitle(ThisWindowPtr).Contains("Google Chrome") == true)
                if (GetTitle(ThisWindowPtr).Contains(text) == true)
                {
                   // MessageBox.Show("Found Window");

                    SwitchToThisWindow(ThisWindowPtr, true);
                }
            }
        }
        #endregion

        #region Clipbord 
        string Cliptemp = "";
        protected void ClipboardGetText()
        {
            var clipboardThread = new Thread(() => ClipBoardThreadWorker());
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();

        }
        private void ClipBoardThreadWorker()
        {
            string a = System.Windows.Clipboard.GetText();

            //string a= System.Windows.Clipboard.GetText();
            // System.Windows.MessageBox.Show("Loop 1 " + a);
            Cliptemp = a;
            //System.Windows.MessageBox.Show("Transferred : " + temp);
        }
        //[STAThread]

        public string ClipGetData()
        {
            int Len = -1;
            int count = 0;
            ClipboardGetText();
            while (Len < 3)
            {
                Len = Convert.ToInt32(Cliptemp.Length);
                // MessageBox.Show("Len : " + Len + "  -   Count " + count);
                if (Len > 2)
                {
                    //MessageBox.Show("data captured : Data is : " + temp);
                    return Cliptemp;
                    break;
                }
                else
                {
                    // MessageBox.Show("else ");
                    if (count >= 5)
                    {
                        count = 0;
                        //MessageBox.Show("sleeping");
                        Thread.Sleep(3000);
                    }
                }
                count++;
            }
            return Cliptemp;
        }
        #endregion

            public void test()
        {
            //// Create new DataTable.
            //DataTable table = new DataTable();

            //// Declare DataColumn and DataRow variables.
            //DataColumn column;
            //DataRow row;

            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "X";
            //table.Columns.Add(column);

            //// Create new DataRow object and add to DataTable.
            //row = table.NewRow();
            //row["X"] = "c21";
            //table.Rows.Add(row);
        }
        public string[] column_Name(string Name)
        {
            string[] CName = new string[0];
            Array.Resize(ref CName, String_to_Array(Name).Length);
            CName = String_to_Array(Name);
            return CName;
        }
        public void DataView(string fileName)
        {
            string fname = fileName;
            string[] filelist = new string[0];
            Array.Resize(ref filelist, String_to_Array(fname).Length);
            filelist = String_to_Array(fname);
            Thread.Sleep(5000);
            foreach (string file in filelist)
            {
                 
                System.Diagnostics.Process.Start(@"" + file);
                Thread.Sleep(3000);
                 
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                // System.Windows.Forms.MessageBox.Show("scroll over");
                Thread.Sleep(3000);
                SwitchToWinows("Phenoix RPA Studio");
                Thread.Sleep(5000);
            }
        }
        public void Invoice (string fileName, string Excel_Path, string Excel_Name)
        {
            string fname = fileName;
            string[] filelist = new string[0];
            Array.Resize(ref filelist, String_to_Array(fname).Length);
            filelist = String_to_Array(fname);

            string[,] final_data = new string[filelist.Length + 1, 5];

            int i = 1;
            //final_data[0, 0] = "Company";
            //final_data[0, 1] = "Invoice #";
            //final_data[0, 2] = "Invoice Date";
            //final_data[0, 3] = "Subtotal";
            //final_data[0, 4] = "Total";


            final_data[0, 0] = "Company";
            final_data[0, 1] = "Invoice #";
            final_data[0, 2] = "Invoice Date";
            final_data[0, 3] = "Subtotal";
            final_data[0, 4] = "Total";
            Thread.Sleep(5000);
            foreach (string file in filelist)
            {
                //c.Open_File(file);
                //c.copy_all();
                //string data = c.ClipGetData();
                //System.Diagnostics.Process.Start(@"" + file);
                //Thread.Sleep(3000);
                ////System.Windows.Forms.MessageBox.Show("scroll down");
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //SendKeys.SendWait("{DOWN}"); Thread.Sleep(500);
                //// System.Windows.Forms.MessageBox.Show("scroll over");
                //Thread.Sleep(3000);
                //SwitchToWinows("Phenoix RPA Studio");
                //Thread.Sleep(5000);
                //System.Windows.Forms.MessageBox.Show("switched");
                string data = PheniexOCR(file);
                //System.Windows.Forms.MessageBox.Show(file);
                //System.Windows.Forms.MessageBox.Show(data);

                string[] string_fun = new string[0];
                int string_Len = String_split_newLine(data, "").Length;
                Array.Resize(ref string_fun, string_Len);
                string_fun = String_split_newLine(data, "");
                //if (i == 0)
                //{
                //    final_data[i,0] = "Company";
                //    final_data[i,1] = "Invoice #";
                //    final_data[i,2] = "Invoice Date";
                //    final_data[i,3] = "Subtotal";
                //    final_data[i,4] = "Total";
                //    i = i + 1;
                //}
                int k = 0;
                //foreach(string a in string_fun)
                //{
                //    System.Windows.Forms.MessageBox.Show(k + " : " + a);
                //    k++;
                //}

                if (string_fun[0].Contains("Vconnect"))
                {
                    final_data[i, 0] = string_fun[0].Replace(" INVOICE", ""); ;
                    final_data[i, 1] = string_fun[3].Replace("Bill To Invoice # ", "");
                    final_data[i, 2] = string_fun[5].Replace("Invoice Date ", "");
                    final_data[i, 3] = string_fun[12].Replace("Subtotal ", "");
                    final_data[i, 4] = string_fun[14].Replace("TOTAL ", "");
                }
                else if (string_fun[0].Contains("Invoice"))
                {
                    final_data[i, 0] = string_fun[1];
                    //final_data[i, 1] = string_fun[5].Replace("BILL TO INVOICE # ", "");
                    final_data[i, 1] = string_fun[6];
                    final_data[i, 2] = string_fun[8].Replace("INVOICE DATE ", "");
                    final_data[i, 3] = string_fun[16].Replace("Subtotal ", "");
                    final_data[i, 4] = string_fun[18].Replace("TOTAL ", "");
                    
                }
                i++;

                //for(int i=0; i<1; i++)
                //{
                //    for (int j = 0; j < 1; j++)
                //    {
                //        if (string_fun[0].Contains("Invoice"))
                //        {   //System.Windows.Forms.MessageBox.Show(string_fun[1] + "\n" + string_fun[5] + "\n" + string_fun[9] + "\n" + string_fun[15] + "\n" + string_fun[17]);
                //            //System.Windows.Forms.MessageBox.Show(i + " : " + string_fun[i]);
                //            final_data[i,j] = 
                //        }
                //    }
                //}
                //System.Windows.Forms.MessageBox.Show("Next file");
            }


            Excel_Write_Cell(@"" + Excel_Path, Excel_Name, final_data, true);
        }
        //public void Excel_Name(string Path, string ExcelName, string[,] final_data)
        //{
        //    Excel_Write_Cell(@"" + Path, ExcelName, final_data, true);
        //}
        

    }
}
