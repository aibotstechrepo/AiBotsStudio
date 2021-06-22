using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ExtendedActivities
{

    public sealed class Excel_Copy_Paste : CodeActivity
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

        protected override void Execute(CodeActivityContext context)
        {
            string SourceFile = context.GetValue(this.Source);
            string DestinationFile = context.GetValue(this.Destination);
            int sheetNumber = context.GetValue(this.Sheet);

            ApplicationClass excelApplicationClass = new ApplicationClass();
            _Workbook finalWorkbook = null;
            Workbook workBook = null;
            Worksheet workSheet = null;
            Worksheet newWorksheet = null;




            try
            {


                //Open the destination WorkBook
                finalWorkbook = excelApplicationClass.Workbooks.Open(DestinationFile, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                //Open the source WorkBook
                workBook = excelApplicationClass.Workbooks.Open(SourceFile, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

                //Open the WorkSheet
                workSheet = (Worksheet)workBook.Sheets[sheetNumber];

                int countWorkSheet = finalWorkbook.Worksheets.Count;

                //newWorksheet = (Worksheet)finalWorkbook.Worksheets.Add(Missing.Value, finalWorkbook.Sheets[countWorkSheet], 1, Missing.Value);

                newWorksheet = (Worksheet)finalWorkbook.Sheets[countWorkSheet];


                //newWorksheet.Name = "Sheet" + countWorkSheet+1;
                //newWorksheet.Name = reportDetailBE.FileName ;
                workSheet.Copy(Missing.Value, newWorksheet);   //Copy from source to destination

                finalWorkbook.Save();
                workBook.Save();
                //Response.Write("Merged !");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (finalWorkbook != null)
                {
                    finalWorkbook.Close(true, Missing.Value, Missing.Value);
                }

                if (workBook != null)
                    workBook.Close(true, Missing.Value, Missing.Value);

                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);

                workSheet = null;

                if (workBook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);

                if (finalWorkbook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(finalWorkbook);

                workBook = null;

                if (excelApplicationClass != null)
                {
                    excelApplicationClass.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplicationClass);
                    excelApplicationClass = null;
                }
            }
        }

    }
}
