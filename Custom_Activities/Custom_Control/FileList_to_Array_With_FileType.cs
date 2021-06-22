using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.IO;

namespace Custom_Control
{

    public partial class FileList_to_Array_With_FileType : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> File_Location { get; set; }

        [Category("Input")]
        [RequiredArgument]  
        public InArgument<string> File_Type { get; set; }

        [Category("Output")]
        public OutArgument<string> Result { get; set; }

        int fs = 0;
        string ft = "";
        protected override void Execute(CodeActivityContext context)
        {
            string file_Location = context.GetValue(this.File_Location);
            if (context.GetValue(this.File_Type).Length > 0)
            {
                string ft = context.GetValue(this.File_Type);
                fs = ft.Length;
                //System.Windows.Forms.MessageBox.Show(fs.ToString());
            }


            //string[] array1 = Directory.GetFiles(@"E:\");
            string[] array1 = Directory.GetFiles(@""+ file_Location);
            string temp = "";
            //System.Windows.Forms.MessageBox.Show(array1.Length.ToString());

            if (fs > 0)
            {
                foreach (string name in array1)
                {
                    string a = name;
                    if (a.Contains(ft) == true)
                    {
                        temp = temp + name + ";";
                    }
                    //System.Windows.Forms.MessageBox.Show(name);
                }
            }
            else
            {
                foreach (string name in array1)
                {
                    temp = temp + name + ";";
                }
            }
            Result.Set(context, temp);
            
        }
    }
}
