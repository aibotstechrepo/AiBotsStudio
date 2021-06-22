using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.IO;

namespace Excel_Activity
{

    public sealed class Excel_Open : CodeActivity
    {
        public enum Visibility
        {
            True,
            False
        }

        [Category("Input")]
        [DisplayName("File path")]
        [RequiredArgument]
        public InArgument<string> Filepath { get; set; }

        [Category("Input")]
        [DisplayName("Sheet Number")]
        //[RequiredArgument]
        public InArgument<Int32> Sheet { get; set; }
        [Category("Input")]
        [DisplayName("Sheet Name")]
        public InArgument<string> SheetName { get; set; }

        [Category("Input")]
        [DisplayName("Visibility")]
        public Visibility vis { get; set; } 
 
        protected override void Execute(CodeActivityContext context)
        {
            string filepath = context.GetValue(this.Filepath);
            int sheet = context.GetValue(this.Sheet);
            string sheetName = context.GetValue(this.SheetName);
            int visval = Convert.ToInt32(vis);
            bool visi = false;
            if (visval == 0)
            {
                visi = true;
            }
            if (visval == 1)
            {
                visi = false;
            }
            //if (File.Exists(filepath))
            //{
                //try
                //{
                    //Excel_Core excel = new Excel_Core();
                    Excel_Core.Open_Excel(filepath, sheet, sheetName, visi);
                //}
                //catch
                //{

                //}

            //}
        }
    }
}
