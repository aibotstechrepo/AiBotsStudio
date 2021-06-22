using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Excel_Activity
{
    public static class Excel_Core
    {
        public static string path = "";
        public static _Application excel = new _Excel.Application();
        public static Workbook wb;
        public static Worksheet ws; 

        public static void Create_Workbook(bool visibile) // New Workbook
        {
            
            //try
            //{

            wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            ws = wb.Worksheets[1];
            excel.Visible = visibile;

            //}
            //catch(Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.ToString());
            //}
        } 

        public static void Open_Excel(string Path, int sheet, string Name, bool visibile)
        {
            path = Path;
            wb = excel.Workbooks.Open(path);

            int count = 0;
            count = wb.Sheets.Count;
            bool found = false;
            if(sheet > 0 )
            {
                int count1 = 0;
                count1 = wb.Sheets.Count;
                if(sheet<=count1)
                {
                    ws = wb.Worksheets[sheet];
                    ws.Activate();
                }
                //else
                //{
                //    ws = wb.Worksheets[1];
                //    ws.Activate();
                //}
            }
            else if(Name!=null)
            {
                string[] Nam = new string[count];
                for (int i = 0; i < count; i++)
                {
                    Worksheet oSheet = (Worksheet)wb.Worksheets[i + 1];
                    if (oSheet.Name == Name)
                    {
                        found = true;
                    }
                }
                if (found == true)
                {
                    ws = wb.Worksheets[Name];
                    ws.Activate(); 
                }
                else
                {
                    wb.Sheets.Add(After: wb.Sheets[wb.Sheets.Count]);
                    ws = wb.Worksheets[wb.Sheets.Count];
                    ws.Name = Name;
                    ws.Activate(); 
                }
            }

            //else
            //{
            //    ws = wb.Worksheets[1];
            //    ws.Activate();
            //} 
            excel.Visible = visibile; 
        }
        
        public static void CreateWorkSheet()
        {
            wb.Sheets.Add(After: wb.Sheets[wb.Sheets.Count]);
        }

        public static string ReadCellByPosition(int i, int j, int sheet, string Name) //Read cell Values by 1,1
        {
            //i++;
            //j++; 

            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            if (i> 0 && j> 0)
            {
                if (ws.Cells[i, j].Value2 != null) 
                    return ws.Cells[i, j].Value2.ToString();
                else
                    return "";
            }
            return "";
            //else
            //    return "";
        }

        public static string ReadCellByRange(string pos, int sheet, string Name) // Read Cell values by Cell range
        {
            // Range range;


            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            Range topExcel = ws.get_Range(pos, Type.Missing);

            topExcel.Select();




            string cellValue = "";
            if(string.IsNullOrEmpty(topExcel.Value2.ToString()))
            {
                cellValue = "";
            }
            else
            {
                cellValue = topExcel.Value2.ToString();
            }
               
            if (cellValue != null)
            {
                //System.Windows.MessageBox.Show(cellValue);
                return cellValue;
            }
            else
                return "";
        }

        public static string ReadCellFormula(string range, int sheet, string Name)
        {
            try
            {
                if (sheet > 0)
                {
                    ws = wb.Worksheets[sheet];
                    ws.Activate();
                }
                else if (Name != null)
                {
                    ws = wb.Worksheets[Name];
                    ws.Activate();
                }

                if (!(((dynamic)((_Worksheet)ws).get_Range((object)range, Type.Missing)[1, 1]).HasFormula() ? true : false))
                {
                    return string.Empty;
                }
                return (string)((dynamic)((_Worksheet)ws).get_Range((object)range, Type.Missing)[1, 1]).Formula.Substring(1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return "";
            }
        }

        public static void WriteCellByPosition(int i, int j, int sheet, string Name, string val) //Write cell Values by 1,1
        {
            //i++;
            //j++;
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }

            ws.Cells[i, j].Value2 = val;
                 
        }

        public static void WriteCellByRange(string pos, int sheet, string Name, string val) // Write Cell values by Cell range
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            Range topExcel = ws.get_Range(pos, Type.Missing);

            topExcel.Select(); 
            topExcel.Value2 = val;  
        }

        public static void save()
        {
            wb.Save();
        }

        public static void saveAs(string path)
        {
            wb.SaveAs(path);
        }

        public static void close_WorkBook()
        {
            wb.Close(); 
        }

        public static void close_Excel()
        {
            excel.Quit();
            //excel.Application.Quit();
            //Marshal.ReleaseComObject(wb); 
            //Marshal.ReleaseComObject(excel);
        }

        public static void deletesheet(int SheetNumber, string Name)
        {
            //try
            //{
                if (SheetNumber > 0)
                {
                    wb.Worksheets[SheetNumber].Delete();
                    
                }
                else if (Name != null)
                {
                    wb.Worksheets[Name].Delete();
                }
            //}
            //catch(Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.Message);
            //}
            
        }

        public static void ProtectSheet(int sheet, string Name)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            ws.Protect();
        }

        public static void ProtectSheet(int sheet,string Name, string Password)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            ws.Protect(Password);
        }

        public static void UnProtectSheet(int sheet,string Name)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            ws.Unprotect();
        }

        public static void UnProtectSheet(int sheet,string Name,string Password)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            ws.Unprotect(Password);
        }

        public static string[,] ReadRangeCellPosition(int starti, int starty, int endi, int endy, int sheet,string Name)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            object[,] holder = range.Value2;
            string[,] returnstring = new string[endi - starti, endy - starty];
            for(int p = 1; p<=endi-starti;p++)
            {
                for(int q = 1; q<=endy - starty;  q++)
                {
                    returnstring[p - 1, q - 1] = holder[p, q].ToString();
                }
            }
            return returnstring;
        }

        public static void WriteRangeCellPosition(int starti, int starty, int endi, int endy, int sheet,string Name, string[,] Data)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = Data;
        }
        
        public static System.Data.DataTable ReadRangeCellRange(string Start, string end, int sheet, string Name)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            //Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            Range range = ws.get_Range(Start, end);
            object[,] holder = range.Value2;

            System.Data.DataTable table = new System.Data.DataTable();

            table = ArraytoDatatable(holder);
            return table;

        }
         
        public static string renameSheet(int sheetNumber, string Oldsheetname,string NewSheetName)
        {
            //try
            //{
                if (sheetNumber > 0)
            {
                ws = wb.Worksheets[sheetNumber];
                ws.Name = NewSheetName;
                ws.Activate();
            }
            else if (Oldsheetname != null)
            {
                ws = wb.Worksheets[Oldsheetname];
                ws.Name = NewSheetName;
                ws.Activate();
            }
                
                return "";
            //}
            //catch
            //{
            //    return "Sheet not found";
            //}
            
            //Worksheet oSheet = (Worksheet)wb.Worksheets[1];
            //oSheet.Name = sheetname;
        }
          
        public static System.Data.DataTable ArraytoDatatable(Object[,] numbers)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int i = 1; i < numbers.GetLength(1); i++)
            {
                dt.Columns.Add("Column" + (i + 1));
            }

            for (var i = 1; i < numbers.GetLength(0); ++i)
            {
                DataRow row = dt.NewRow();
                for (var j = 1; j < numbers.GetLength(1); ++j)
                {
                    row[j] = numbers[i, j];
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static void Invloke_Macros(object Macro, int sheet, string Name)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            excel.Run(Macro);
        }

        public static int numberOfSheets()
        {
            int count = 0;
            count = wb.Sheets.Count;
            return count;
        }

        public static string[] ListOFSheetNames()
        {
            int count = 0;
            count = wb.Sheets.Count;
            string[] Nam = new string[count];
            for (int i=0;i<count;i++)
            {
                Worksheet oSheet = (Worksheet)wb.Worksheets[i+1];
                Nam[i] = oSheet.Name;
            }
            return Nam;
        }

        public static void sheetCopyMove(int Sheet, bool Copy)
        {
            Worksheet newWorksheet = (Worksheet)wb.Worksheets.Add();
            newWorksheet.Name = ws.Name;
            Create_Workbook(true);
            newWorksheet.Copy(); 
        }

        public static void DeleteRange(string rangeFrom, string rangeTo, int sheet, string Name, int shift)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            Range TempRange = ws.get_Range(rangeFrom, rangeTo);
            if(shift == 0)
            {
                TempRange.Cells.Clear();
            }
            else if(shift == 1 )
            {
                TempRange.Cells.Delete(Type.Missing);
            }
            else if(shift == 2)
            {
                TempRange.EntireRow.Delete(Type.Missing);
            }
        }

        public static void FindReplace(string key, string replace, bool Case,int wordtype)
        {
            if(wordtype == 0)
            {
                excel.Cells.Replace(key, replace, XlLookAt.xlPart, XlSearchOrder.xlByRows, Case);
            }
            else if(wordtype == 1)
            {
                excel.Cells.Replace(key, replace, XlLookAt.xlWhole, XlSearchOrder.xlByRows, Case);
            }
            
        }

        public static string find(string key, int sheet, string Name, string from, string to, bool wordType, bool Case)
        {
            Range currentFind = null;
            Range Fruits;
            object missing = System.Reflection.Missing.Value;
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            if (from == null || to == null)
            {
                Fruits = excel.get_Range("A1", "XFD1048576");

            }
            else
            {
                Fruits = excel.get_Range(from, to);
            }

            // You should specify all these parameters every time you call this method,
            // since they can be overridden in the user interface. 
            if (wordType == true)
            {
                currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, Case, missing, missing);
            }
            else
            {
                currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlWhole, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, Case, missing, missing);

            }

            string loc = "";
            if(currentFind != null)
            {
                loc = currentFind.Address;

                loc = loc.Replace("$", "");
                currentFind.Activate();
            }
           
            return loc;
        }
        public static string[] findAll(string key, int sheet,string Name, string from, string to,bool wordType, bool Case)
        {
            if (sheet > 0)
            {
                ws = wb.Worksheets[sheet];
                ws.Activate();
            }
            else if (Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            string[] data = new string[0];
            int i = 0;

            Range currentFind = null;
            Range firstFind = null;
            object missing = System.Reflection.Missing.Value;
            Range Fruits ;
            if (from == null || to == null)
            {
                Fruits = excel.get_Range("A1", "XFD1048576");

            }
            else
            {
                Fruits = excel.get_Range(from, to);
            }
            
            // You should specify all these parameters every time you call this method,
            // since they can be overridden in the user interface. 
            if(wordType == true)
            {
                currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, Case, missing, missing);
            }
            else
            {
                currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlWhole, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, Case, missing, missing);

            }
            // currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlPart, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, false, missing, missing);
            //  currentFind = Fruits.Find(key, missing, XlFindLookIn.xlValues, XlLookAt.xlWhole, XlSearchOrder.xlByRows, XlSearchDirection.xlNext, true, missing, missing);
            string loc1 = "";
            while (currentFind != null)
            {
                // Keep track of the first range you find. 
                if (firstFind == null)
                {
                    firstFind = currentFind;
                    Array.Resize(ref data, data.Length + 1);
                    loc1 = currentFind.Address;

                    loc1 = loc1.Replace("$", "");
                    data[i] = loc1;
                    i++;
                }

                // If you didn't move to a new range, you are done.
                else if (currentFind.get_Address(XlReferenceStyle.xlA1)
                      == firstFind.get_Address(XlReferenceStyle.xlA1))
                {
                    break;
                }

                //currentFind.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                //currentFind.Font.Bold = true;

                currentFind = Fruits.FindNext(currentFind);
                
                string loc = "";
                if (currentFind != null)
                {
                    loc = currentFind.Address;

                    loc = loc.Replace("$", "");
                    currentFind.Activate();
                    if(firstFind != currentFind)
                    {
                        if(loc!=loc1)
                        {
                            Array.Resize(ref data, data.Length + 1);
                            data[i] = loc;
                            i++;
                        } 
                    }
                }
                 

                //System.Windows.MessageBox.Show(loc);
            }
             
            return data;
        }

        public static void CopySheet(string sheetName, int sheetNumber)
        {
            if (sheetNumber > 0)
            {
                ws = wb.Worksheets[sheetNumber]; 
            }
            else if (sheetName != null)
            {
                ws = wb.Worksheets[sheetName]; 
            }
            ws.Copy(After: wb.Sheets[wb.Sheets.Count]);
        }
        public static void Sort(int col, int odr)
        {
            dynamic allDataRange = ws.UsedRange;
            if (odr ==0)
            {
                allDataRange.Sort(allDataRange.Columns[col], _Excel.XlSortOrder.xlAscending);
            }
            else if(odr == 1)
            {
                allDataRange.Sort(allDataRange.Columns[col], _Excel.XlSortOrder.xlDescending);
            }
        }
        public static void SheetActivate(int Number, string Name) 
        {
            //try
            //{
            
            if (Number> 0)
            {
                ws = wb.Worksheets[Number];
                ws.Activate();
            }
            else if(Name != null)
            {
                ws = wb.Worksheets[Name];
                ws.Activate();
            }
            //}
            //catch
            //{
            //    ;
            //}
        }
        //---------------------------------------------- Recently Added -------------------------------------------------------------------

        public static void WrapText(string From, string To = null, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false, bool Enable = true)
        {
            if (Entire_Sheet)
            {
                ws.Cells.WrapText = Enable;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(To))
                {
                    From = $"{From}{":"}{To}";
                }
                if (Entire_Row)
                {
                    ws.Range[From].EntireRow.Cells.WrapText = Enable;
                }
                if (Entire_Column)
                {
                    ws.Range[From].EntireColumn.Cells.WrapText = Enable;
                }
                ws.Range[From].Cells.WrapText = Enable;
            }
        }
        public static void Merge(string From, string To, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false)
        {
            if (Entire_Sheet)
            {
                ws.Cells.Merge();
            }
            else
            {
                if (Entire_Row)
                {
                    ws.get_Range(From, To).EntireRow.Merge();
                }
                if (Entire_Column)
                {
                    ws.get_Range(From, To).EntireColumn.Merge();
                }

                ws.get_Range(From, To).Merge();
            }
        }
        public static void UnMerge(string From, string To, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false)
        {
            if (Entire_Sheet)
            {
                ws.Cells.UnMerge();
            }
            else
            {
                if (Entire_Row)
                {
                    ws.get_Range(From, To).EntireRow.UnMerge();
                }
                if (Entire_Column)
                {
                    ws.get_Range(From, To).EntireColumn.UnMerge();
                }

                ws.get_Range(From, To).UnMerge();
            }
        }
        public static void H_Align_Left(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
            ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
        }
        public static void H_Align_Right(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
            ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignRight;
        }
        public static void H_Align_Center(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }
        public static void H_Align_Justify(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignJustify;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignJustify;
            ws.get_Range(From, To).Cells.HorizontalAlignment = XlHAlign.xlHAlignJustify;
        }
        public static void V_Align_Left(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignLeft;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignLeft;
            ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignLeft;
        }
        public static void V_Align_Right(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignRight;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignRight;
            ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignRight;
        }
        public static void V_Align_Center(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
            ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;
        }
        public static void V_Align_Justify(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignJustify;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignJustify;
            ws.get_Range(From, To).Cells.VerticalAlignment = XlHAlign.xlHAlignJustify;
        }
        public static void Bold_Cell(string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            if (Entire_Row)
                ws.get_Range(From, To).Cells.EntireRow.Font.Bold = true;
            if (Entire_Column)
                ws.get_Range(From, To).Cells.EntireColumn.Font.Bold = true;
            ws.get_Range(From, To).Cells.Font.Bold = true;
        }
        public static void Fonts(string FontName, string From, string To, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false, bool Entire_Excel = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Column) range = range.EntireColumn;
            if (Entire_Sheet) ws.Rows.Font.Name = FontName;
            if (Entire_Excel) excel.StandardFont = FontName;

            range.Style.Font.Name = FontName;
        }
        public static void FontSize(double size, string From, string To, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false, bool Entire_Excel = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Column) range = range.EntireColumn;
            if (Entire_Sheet) ws.Rows.Font.Size = size;
            if (Entire_Excel) excel.StandardFontSize = size;

            range.Style.Font.Size = size;
        }
        public static void Background_Color(XlRgbColor color, string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Column) range = range.EntireColumn;
            range.Interior.Color = color;
        }
        public static void Font_Color(XlRgbColor color, string From, string To, bool Entire_Row = false, bool Entire_Column = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Column) range = range.EntireColumn;
            range.Font.Color = color;
        }
        public static void AutoFitt(string From, string To, bool Row = false, bool Column = false)
        {

            ws.Cells.AutoFit();
            //var range = ws.get_Range(From, To);
            //if (Row) range = range.EntireRow.AutoFit();
            //if (Column) range = range.EntireColumn.AutoFit();
            //range.AutoFit();
        }
        public static void BorderAllSide(string From, string To)
        {
            var rowToBottomBorderizeRange = ws.get_Range(From, To);
            Borders border = rowToBottomBorderizeRange.Borders;
            border[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static bool ExcelChart(string RangeFrom = "A1", string RangeTo = "XFD1048576", XlChartType ChartType = XlChartType.xlLine, string ChartTitle = "Chart", string CategoryTitle = "Category", string ValueTitle = "Value", double PositionLeft = 100, double PositionTop = 10, double ChartWidth = 300, double ChartHeight = 300, int ChartLayout = 0, double YAxisMinimum = 0, double YAxisMaximum = 0, int DataFromSheet = 0)
        {
            try
            {
                var charts = ws.ChartObjects() as ChartObjects;
                var chartObject = charts.Add(PositionLeft, PositionTop, ChartWidth, ChartHeight) as ChartObject;
                var chart = chartObject.Chart;
                Range range = null;
                if (DataFromSheet > 0)
                {
                    Worksheet ws1 = wb.Worksheets[DataFromSheet];
                    range = ws1.get_Range(RangeFrom, RangeTo);
                }
                else
                {
                    range = ws.get_Range(RangeFrom, RangeTo);
                }

                // Set chart range.
                //var range = ws.get_Range(RangeFrom, RangeTo);
                chart.SetSourceData(range);

                // Set chart properties.
                chart.ChartType = ChartType;
                if (ChartLayout > 0)
                {
                    try
                    {
                        chart.ApplyLayout(ChartLayout);
                    }
                    catch
                    {
                        ;
                    }

                }
                if (YAxisMinimum > 0)
                {
                    try
                    {
                        Axis ax = chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary) as Axis;
                        ax.MinimumScale = YAxisMinimum;
                    }
                    catch
                    {
                        ;
                    }

                }
                if (YAxisMaximum > 0)
                {
                    try
                    {
                        Axis ax = chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary) as Axis;
                        ax.MaximumScale = YAxisMaximum;
                    }
                    catch
                    {
                        ;
                    }

                }

                chart.ChartWizard(Source: range, Title: ChartTitle, CategoryTitle: CategoryTitle, ValueTitle: ValueTitle);
                return true;
            }
            catch
            {
                ;
            }
            return false;
        }
        public static void InsertRow(int RowNumber)
        {
            Range line = (Range)ws.Rows[RowNumber];
            line.Insert();
        }
        public static void InsertColumn(string CellAddress)
        {
            if (!string.IsNullOrWhiteSpace(CellAddress))
            {
                Range oRng = ws.Range[CellAddress];
                oRng.EntireColumn.Insert(XlInsertShiftDirection.xlShiftToRight,
                    XlInsertFormatOrigin.xlFormatFromRightOrBelow);
            }
        }
        public static string ColumnAdress(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        public static int ColumnNumber(string columnAdress)
        {
            columnAdress = new String(columnAdress.Where(c => Char.IsLetter(c)).ToArray()).ToUpper();
            int[] digits = new int[columnAdress.Length];
            for (int i = 0; i < columnAdress.Length; ++i)
            {
                digits[i] = Convert.ToInt32(columnAdress[i]) - 64;
            }
            int mul = 1; int res = 0;
            for (int pos = digits.Length - 1; pos >= 0; --pos)
            {
                res += digits[pos] * mul;
                mul *= 26;
            }
            return res;
        } 
        public static string CellIncrementDecrement(string cellAddress, int row = 0, int column = 0)
        {
            try
            {
                Range range = ws.get_Range(cellAddress, Type.Missing);
                string data = range.Offset[row, column].Address;
                data = data.Replace("$", "");
                return data;
            }
            catch
            {
                ;
            }
            return null;
        }
        public static string LastUsedCell()
        {
            Range last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            string data = last.Address;
            data = data.Replace("$", "");
            string[] data1 = data.Split(':');
            if (data1.Length > 0)
            {
                try
                {
                    if (data1.Length == 2)
                    {
                        return data1[1];
                    }
                    else
                    {
                        return data1[0];
                    }

                }
                catch
                {

                }
            }
            return null;
        }
        public static string GetLastRowByCellAddress(string CellAddress)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(CellAddress))
                {
                    CellAddress = new String(CellAddress.Where(c => Char.IsLetter(c)).ToArray());
                    int usedRows = ws.Range[CellAddress + ws.Rows.Count.ToString()].End[XlDirection.xlUp].Row;
                    return $"{CellAddress}{usedRows}";
                }
            }
            catch
            {
                ;
            }
            return null;

        }
        public static string GetLastColumnByCellAddress(string CellAddress)
        {
            string numeric = new String(CellAddress.Where(Char.IsDigit).ToArray());
            int row = Convert.ToInt32(numeric);
            if (row > 0)
            {
                int i1 = 1;
                while (row > 0)
                {
                    string temp = $" {ws.Cells[row, i1].Value }";
                    if (String.IsNullOrEmpty(temp) || String.IsNullOrWhiteSpace(temp) == true)
                    {
                        break;
                    }
                    i1++;
                }
                CellAddress = ColumnAdress(i1 - 1);
                return $"{CellAddress}{numeric}";
            }
            return null;
        }
        public static void SetPageOrientation(bool Landscape = false)
        {
            if (Landscape)
            {
                ws.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            }
            else
            {
                ws.PageSetup.Orientation = XlPageOrientation.xlPortrait;
            }
        }
        public static void SetColumnWidth(string From, string To, double Width, bool Entire_Row = false, bool Entire_Sheet = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Sheet) ws.Cells.ColumnWidth = Width;
            range.ColumnWidth = Width;
        }
        public static void SetRowHeight(string From, string To, double Height, bool Entire_Column = false, bool Entire_Sheet = false)
        {
            var range = ws.get_Range(From, To);
            if (Entire_Column) range = range.EntireColumn;
            if (Entire_Sheet) ws.Cells.RowHeight = Height;
            range.RowHeight = Height;
        }
        public static bool SetPageSize(XlPaperSize paperSize = XlPaperSize.xlPaperA4)
        {
            try
            {
                ws.PageSetup.PaperSize = paperSize;
                return true;
            }
            catch
            {
                ;
            }
            return false;
        }
        public static bool ExportAsPDF(string exportPath, string fileName, string RangeFromTo = null)
        {
            try
            {
                fileName = Path.Combine(exportPath, fileName);
                ws.PageSetup.PrintArea = RangeFromTo;
                wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, fileName);
                return true;
            }
            catch
            {
                ;
            }
            return false;
        }
        public static void SetMarginTop(double Top = 1.0)
        {
            try
            {
                ws.PageSetup.TopMargin = Top;
            }
            catch
            { }

        }
        public static void SetMarginBottom(double Bottom = 1.0)
        {
            try
            {
                ws.PageSetup.BottomMargin = Bottom;
            }
            catch
            { }

        }
        public static void SetMarginLeft(double Left = 1.0)
        {
            try
            {
                ws.PageSetup.LeftMargin = Left;
            }
            catch
            { }

        }
        public static void SetMarginRight(double Right = 1.0)
        {
            try
            {
                ws.PageSetup.RightMargin = Right;
            }
            catch
            { }

        }
        public static string GetLastColumn()
        {
            Range last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            int cellColumn = last.Column;

            return $"{ColumnAdress(cellColumn)}{last.Row}";
        }
        public static void BorderLeft(string From, string To)
        {
            var rowToBottomBorderizeRange = ws.get_Range(From, To);
            Borders border = rowToBottomBorderizeRange.Borders;
            border[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static void BorderRight(string From, string To)
        {
            var rowToBottomBorderizeRange = ws.get_Range(From, To);
            Borders border = rowToBottomBorderizeRange.Borders;
            border[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static void BorderTop(string From, string To)
        {
            var rowToBottomBorderizeRange = ws.get_Range(From, To);
            Borders border = rowToBottomBorderizeRange.Borders;
            border[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static void BorderBottom(string From, string To)
        {
            var rowToBottomBorderizeRange = ws.get_Range(From, To);
            Borders border = rowToBottomBorderizeRange.Borders;
            border[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            //border[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
        }
        public static void HideWorksheet(int sheetNumber)
        {
            if (sheetNumber > 0)
            {
                ws = wb.Worksheets[sheetNumber];
                ws.Activate();
                ws.Visible = XlSheetVisibility.xlSheetHidden;
            }
        }
        public static void SetCellFormat(string from, string to, bool Entire_Row = false, bool Entire_Column = false, bool Entire_Sheet = false)
        {
            var range = ws.get_Range(from, to);
            if (Entire_Row) range = range.EntireRow;
            if (Entire_Column) range = range.EntireColumn;
            if (Entire_Sheet) ws.Columns.NumberFormat = "@";

            range.NumberFormat = "@";
        }
        public static int[] PageBreak()
        {
            excel.ActiveWindow.View = XlWindowView.xlPageBreakPreview;
            ws.DisplayPageBreaks = false;
            ws.DisplayAutomaticPageBreaks = false;
            int[] rows = new int[0];
            for (int i = 1; i <= ws.HPageBreaks.Count; i++)
            {
                Array.Resize(ref rows, rows.Length + 1);
                rows[i - 1] = ws.HPageBreaks[i].Location.Row - 1;
            }
            return rows;
        }
        public static void CopyRow(string sourceFrom, string sourceTo, string destinationFrom, string destinationTo)
        {
            Range from = ws.Range[sourceFrom + ":" + sourceTo];
            Range to = ws.Range[destinationFrom + ":" + destinationTo];

            from.Copy(to);
        }
        public static void RightPageHeader(string HeaderName)
        {
            try
            {
                ws.PageSetup.RightHeader = HeaderName;
            }
            catch { }
        }
        public static void RightFooter(string PageNumber)
        {
            try
            {
                ws.PageSetup.RightFooter = PageNumber;
            }
            catch { }
        }
        public static void CenterFooter(string PageNumber)
        {
            try
            {
                ws.PageSetup.CenterFooter = PageNumber;
            }
            catch { }
        }
        public static void LeftFooter(string PageNumber)
        {
            try
            {
                ws.PageSetup.LeftFooter = PageNumber;
            }
            catch { }
        }
    }
}
