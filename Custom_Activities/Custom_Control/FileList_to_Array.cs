using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;
using System.ComponentModel;

namespace Custom_Control
{

    public sealed class FileList_to_Array : CodeActivity
    {
        CustomFunction obj = new CustomFunction();

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> File_Location { get; set; }

        [Category("Output")]
        public OutArgument<string> Result { get; set; }

        //int fs = 0;
        //string ft = "";
        protected override void Execute(CodeActivityContext context)
        {
            string file_Location = context.GetValue(this.File_Location);
            string temp = obj.File_List_Array(file_Location, "");
            
            Result.Set(context, temp);

            //string file_Location = context.GetValue(this.File_Location);
            ////string[] array1 = Directory.GetFiles(@"E:\");
            //string[] array1 = Directory.GetFiles(@""+ file_Location);
            //string temp = "";
            ////System.Windows.Forms.MessageBox.Show(array1.Length.ToString());

            //if (fs > 0)
            //{
            //    foreach (string name in array1)
            //    {
            //        if (name.Contains(ft) == true)
            //        {
            //            temp = temp + name + ";";
            //        }
            //         //System.Windows.Forms.MessageBox.Show(name);
            //    }
            //}
            //else
            //{
            //    foreach (string name in array1)
            //    {
            //        temp = temp + name + ";";
            //    }
            //}
            //Result.Set(context, temp);

        }
    }
}
