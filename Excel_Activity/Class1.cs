using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace Excel_Activity
{
   class Excel_MAin
    {
        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook excelworkBook;
        Microsoft.Office.Interop.Excel.Worksheet excelSheet;
        //Microsoft.Office.Interop.Excel.Range excelCellrange;


        public bool Create_Excel(string Excel_Name, string Sheet_Name,bool visibility)
        {
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = visibility;
            excel.DisplayAlerts = false;

            excelworkBook = excel.Workbooks.Add(Type.Missing);

            excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
            excelSheet.Name = Sheet_Name;
            return false;
        }

        public bool Range_Write(string Excel_Name, string Sheet_Name, bool visibility)
        {
            //excelSheet.Cells[]
            return false;
        }


            public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;


                excelSheet.Cells[1, 1] = ReporType;
                excelSheet.Cells[1, 2] = "Date : " + DateTime.Now.ToShortDateString();

                // loop through each row and add values to our sheet
                int rowcount = 2;

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();

                        //for alternate rows
                        if (rowcount > 3)
                        {
                            if (i == dataTable.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                    FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                                }

                            }
                        }

                    }

                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
                FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            //catch (Exception ex)
            catch 
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }

        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }


        //public void write()
        //{
            

        //    Excel.ApplicationClass oExcelApp = new Excel.ApplicationClass();
        //    object readOnly = false;
        //    object isVisible = true;
        //    object missing = System.Reflection.Missing.Value;

        //    Excel.Workbook oExcelWorkBook = oExcelApp.Workbooks.Open(@"d:\1.xlsx", 
        //                                    missing, readOnly,
        //                                    missing, missing, missing,
        //                                    missing, missing, missing,
        //                                    missing, missing, missing,
        //                                    missing, missing, missing);
        //    //
        //    // Get sheet Count and store the number of sheets.
        //    //
        //    int numSheets = oExcelWorkBook.Sheets.Count;

        //    //
        //    // Iterate through the sheets. They are indexed starting at 1.
        //    //
        //    for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
        //    {
        //        Excel.Worksheet sheet = (Excel.Worksheet)oExcelWorkBook.Sheets[sheetNum];

        //        //
        //        // Take the used range of the sheet. 
        //        //
        //        Excel.Range excelRange = sheet.UsedRange;
        //        int RowCount = excelRange.Rows.Count;
        //        int ColumnCount = excelRange.Columns.Count;
        //        for (int r = 1; r <= RowCount; r++)
        //        {
        //            for (int c = 1; c <= ColumnCount; c++)
        //            {
        //                dynamic cell = excelRange.Cells[r, c];
        //                try
        //                {
        //                    if (cell.Locked == false)
        //                    {
        //                        string content = cell.Value2;
        //                        if (content != null && !content.Trim().Equals(""))
        //                        {
        //                            content = content.Trim();
        //                            cell.Value2 = cell.Value2 + " - This is a test";
        //                        }
        //                    }
        //                }
        //                catch (Exception)
        //                {
        //                    // we are using dynamic type for cell variable so
        //                    // the variable might not have all the properties we used in our code
        //                }

        //            }
        //        }

        //    }

        //    oExcelWorkBook.Save();
        //    oExcelApp.Application.Quit();
        //}

    }

}
