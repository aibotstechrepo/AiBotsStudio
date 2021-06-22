using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.IO;

namespace File_Operations
{

    public sealed class File_List_to_Array : CodeActivity
    { 
        public enum file_options
        {
            All,
            Files_Only,
            Folders_Only,
            Specified_File_type
        }

        [Category("Input")]
        [RequiredArgument]
        [DisplayName("File Location")]
        public InArgument<string> File_Location { get; set; }

        [Category("Input")] 
        [DisplayName("Retrive")]
        public file_options fi_choice { get; set; }

        [Category("Input")]
        [DisplayName("File Type")]
        [DefaultValue ("All")]
        public InArgument<string> File_Type { get; set; }

        //[Category("Output")]
        //[DisplayName("File List")]
        //public OutArgument<string> File_list { get; set; }

        [Category("Output")]
        [DisplayName("File List Array")]
        public OutArgument<System.String[]> File_list_A { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string file_Location = context.GetValue(this.File_Location);
            string file_type = context.GetValue(this.File_Type);

            String[] subDirectories;
            String[] subFiles;
            subDirectories = System.IO.Directory.GetDirectories(@"" + file_Location);
            subFiles = System.IO.Directory.GetFiles(file_Location);
            string di = Array_to_String(subDirectories);
            string sf = Array_to_String(subFiles);
             
            int val = Convert.ToInt32(fi_choice);
            if (val == 0)
            {
                List<String> appendfiles = new List<String>(subDirectories.Concat<string>(subFiles));
                String[] finalArray = appendfiles.ToArray();
                File_list_A.Set(context, finalArray);
                //File_list.Set(context, di + ":::" + sf);
                Result.Set(context, true);
            }
            else if (val == 1)
            {
                File_list_A.Set(context, subFiles);
                //File_list.Set(context, sf);
                Result.Set(context, true);
            }
            else if(val == 2)
            {
                File_list_A.Set(context, subDirectories);
                //File_list.Set(context, di);
                Result.Set(context, true);
            }
            else if(val == 3)
            { 
                string[] filePaths = Directory.GetFiles(@"" + file_Location, "*." + file_type);
                string sf1 = Array_to_String(filePaths);
                //File_list.Set(context, sf1);
                File_list_A.Set(context, filePaths);
                Result.Set(context, true);
                //System.Windows.MessageBox.Show(sf1);
            }
            else
            {
                Result.Set(context, false);
            }
              
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
    }
}
