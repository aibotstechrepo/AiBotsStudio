using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel; 

namespace Excel_Activity
{ 
    public sealed class ExcelSheetCopy : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Source File")]
        [RequiredArgument]
        public InArgument<string> Source { get; set; }

        [Category("Input")]
        [DisplayName("Destination File")]
        [RequiredArgument]
        public InArgument<string> Destination { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Number")]
        [RequiredArgument]
        public InArgument<int> Sheet { get; set; }

       
        //protected override void Execute(CodeActivityContext context)
        //{
        //    string SourceFile = context.GetValue(this.Source);
        //    string DestinationFile = context.GetValue(this.Destination);
        //    int sheetNumber = context.GetValue(this.Sheet);

        //    ApplicationClass excelApplicationClass = new ApplicationClass();
        //    _Workbook finalWorkbook = null;
        //    Workbook workBook = null;
        //    Worksheet workSheet = null;
        //    Worksheet newWorksheet = null;




        //    try
        //    {


        //        //Open the destination WorkBook
        //        finalWorkbook = excelApplicationClass.Workbooks.Open(Server.MapPath("Test.xlsx"), false, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

        //        //Open the source WorkBook
        //        workBook = excelApplicationClass.Workbooks.Open(Server.MapPath("bargarh.xlsx"), false, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

        //        //Open the WorkSheet
        //        workSheet = (Worksheet)workBook.Sheets[1];

        //        int countWorkSheet = finalWorkbook.Worksheets.Count;

        //        //newWorksheet = (Worksheet)finalWorkbook.Worksheets.Add(Missing.Value, finalWorkbook.Sheets[countWorkSheet], 1, Missing.Value);

        //        newWorksheet = (Worksheet)finalWorkbook.Sheets[countWorkSheet];


        //        //newWorksheet.Name = "Sheet" + countWorkSheet+1;
        //        //newWorksheet.Name = reportDetailBE.FileName ;
        //        workSheet.Copy(Missing.Value, newWorksheet);   //Copy from source to destination

        //        finalWorkbook.Save();
        //        workBook.Save();
        //        //Response.Write("Merged !");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (finalWorkbook != null)
        //        {
        //            finalWorkbook.Close(true, Missing.Value, Missing.Value);
        //        }

        //        if (workBook != null)
        //            workBook.Close(true, Missing.Value, Missing.Value);

        //        if (workSheet != null)
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

        //        workSheet = null;

        //        if (workBook != null)
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);

        //        if (finalWorkbook != null)
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(finalWorkbook);

        //        workBook = null;

        //        if (excelApplicationClass != null)
        //        {
        //            excelApplicationClass.Quit();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplicationClass);
        //            excelApplicationClass = null;
        //        }
        //    }
        //}

        protected override void Execute(CodeActivityContext context)
        {
            string SourceFile = context.GetValue(this.Source);
            string DestinationFile = context.GetValue(this.Destination);
            int sheetNumber = context.GetValue(this.Sheet);
            //System.Windows.MessageBox.Show("SourceFile : " + SourceFile);
            //System.Windows.MessageBox.Show("DestinationFile : " + DestinationFile);
            if (File.Exists(SourceFile))
            {
                if (File.Exists(DestinationFile))
                {
                    //System.Windows.MessageBox.Show("Found");
                    Excel.Application excelApp;

                    //string sourceFileName = "1.xlsx"; //Source excel file
                    //string tempFileName = "2.xlsx";

                    //string folderPath = @"D:\";

                    //string sourceFilePath = System.IO.Path.Combine(folderPath, sourceFileName);
                    //string destinationFilePath = System.IO.Path.Combine(folderPath, tempFileName);

                    System.IO.File.Copy(SourceFile, DestinationFile, true);

                    /************************************************************************************/

                    excelApp = new Excel.Application();
                    Excel.Workbook wbSource, wbTarget;
                    Excel.Worksheet currentSheet;

                    wbSource = excelApp.Workbooks.Open(SourceFile);
                    wbTarget = excelApp.Workbooks.Open(DestinationFile);

                    currentSheet = wbSource.Worksheets[sheetNumber]; //Sheet which you want to copy
                    currentSheet.Name = "NewSheet"; //Give a name to destination sheet

                    currentSheet.Copy(wbTarget.Worksheets[1]); //                    Actual copy
                    wbSource.Close(false);
                    wbTarget.Close(true);
                    excelApp.Quit();

                    //System.IO.File.Delete(SourceFile);
                    //System.IO.File.Move(DestinationFile, SourceFile);
                }
                else
                {
                    //System.Windows.MessageBox.Show("Destination not found");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Source not found");
            }

        }


    }
}
