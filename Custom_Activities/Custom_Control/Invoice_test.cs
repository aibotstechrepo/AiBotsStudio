using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Custom_Control
{

    public sealed class Invoice_test : CodeActivity
    {
        public InArgument<string> Text { get; set; }
        //public OutArgument<string[]> Text { get; set; }

        CustomFunction c = new CustomFunction();
        protected override void Execute(CodeActivityContext context)
        {

            //string a = c.dataread();
            //System.Windows.Forms.MessageBox.Show("fun 2 :" + a);
            //System.Windows.Forms.MessageBox.Show("len :" + a.Length.ToString());
            //Text.Set(context, a);

            ////------------------------------------------------------ obj 1--------------------------------
            ////System.Windows.Forms.MessageBox.Show("called");
            //string[] filelist = new string[0];
            ////System.Windows.Forms.MessageBox.Show("Array ");
            //string FileLocation = @"E:\AIBOTS_Production\autoit_Programs\Jagdeesh\invoice processing\Invoice PDF";
            //string FileType = ".pdf";
            //int FileListSize = 6;
            ////System.Windows.Forms.MessageBox.Show("initiallized ");

            //string[,] final_data = new string[6,5]; 
            //FileListSize = c.File_List_Array(FileLocation, FileType).Length;
            ////System.Windows.Forms.MessageBox.Show(FileListSize.ToString());
            //Array.Resize(ref filelist, FileListSize);
            ////filelist = c.File_List_Array(FileLocation, FileType);
            ////filelist = "";
            ////System.Windows.Forms.MessageBox.Show(FileListSize.ToString());
            ////------------------------------------------------------ obj 1--------------------------------
            string fname = context.GetValue(this.Text);
            string[] filelist = new string[0];
            Array.Resize(ref filelist, c.String_to_Array(fname).Length);
            filelist = c.String_to_Array(fname);

            string[,] final_data = new string[filelist.Length + 1, 5];
            
            int i = 1;
            final_data[0, 0] = "Company";
            final_data[0, 1] = "Invoice #";
            final_data[0, 2] = "Invoice Date";
            final_data[0, 3] = "Subtotal";
            final_data[0, 4] = "Total";
            foreach (string file in filelist)
            {
                //c.Open_File(file);
                //c.copy_all();
                //string data = c.ClipGetData();
                string data = c.PheniexOCR(file);
                //System.Windows.Forms.MessageBox.Show(file);
                //System.Windows.Forms.MessageBox.Show(data);

                string[] string_fun = new string[0];
                int string_Len = c.String_split_newLine(data, "").Length;
                Array.Resize(ref string_fun, string_Len);
                string_fun = c.String_split_newLine(data, "");
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
            c.Excel_Write_Cell(@"E:", "test_9_Invoice", final_data, true);

        }
    }
}
