using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;

namespace File_Operations
{

    public sealed class File_Copy_Move : CodeActivity
    {

        public enum oper
        {
            Copy,
            Move
        }
        public enum Ftype
        {
            All,
            One
        }
        public enum over_ride
        {
            True,
            False,
            KeepBothFiles
        }

        [Category("Input")]
        [DisplayName("Operation")]
        public oper op { get; set; }

        [Category("Input")]
        [DisplayName("File")]
        public Ftype ft { get; set; }

        [Category("Input")]
        [DisplayName("Override If exist")]
        public over_ride OV { get; set; }


        [Category("Input")]
        [DisplayName("File Name")]
        public InArgument<string> File_Name { get; set; }

        [Category("Input")]
        [DisplayName("Source Location")] 
        public InArgument<string> Source_Location{ get; set; }
        
        [Category("Input")]
        [DisplayName("Destination Location")] 
        public InArgument<string> Destination_Location { get; set; }

        [Category("Output")]
        [DisplayName("Result")]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int oval = Convert.ToInt32(op);
            int tval = Convert.ToInt32(ft);
            int ov = Convert.ToInt32(OV);

            string fileName = context.GetValue(this.File_Name);
            //System.Windows.MessageBox.Show(fileName);
            string sourcePath = @"" + context.GetValue(this.Source_Location);
            string targetPath = @"" + context.GetValue(this.Destination_Location);
            bool ovv = true;
            bool replace = false;
            if(ov== 0)
            {
                ovv = true;
            }
            else if (ov == 1)
            {
                ovv = false;
            }
            else if (ov == 2)
            {
               
                replace = true;
            }
            else
            {
                ovv = true;
            }


            if (oval == 0)
            {
                if(tval == 1)
                { 
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    //System.Windows.MessageBox.Show(fileName);


                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }
                    if (replace == true)
                    {

                        //fileName = System.IO.Path.GetFileName(sourcePath);
                        //System.Windows.MessageBox.Show(fileName);
                    fileloop:
                        string destFile = System.IO.Path.Combine(targetPath, fileName);

                        if (System.IO.File.Exists(destFile))
                        {
                            destFile = System.IO.Path.Combine(targetPath, "Copy-" + fileName);
                            fileName = "Copy-" + fileName;
                            //System.Windows.MessageBox.Show(fileName);
                            goto fileloop;
                        }
                        else
                        {
                            System.IO.File.Copy(sourceFile, destFile,false);
                        }

                        Result.Set(context, true);
                    }
                    else
                    {
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        if (ovv == true)
                        {
                            if (System.IO.Directory.Exists(sourceFile))
                            {
                                System.IO.File.Copy(sourceFile, destFile, ovv);
                                Result.Set(context, true);
                            }
                            else
                            {
                                System.IO.File.Copy(sourceFile, destFile, ovv);
                                Result.Set(context, true);
                            }
                        }
                        else
                        {
                            try
                            {
                                System.IO.File.Copy(sourceFile, destFile, ovv);
                                Result.Set(context, true);
                            }
                            catch
                            {
                                Result.Set(context, false);
                            }

                        }
                    }

                   // System.IO.File.Copy(sourceFile, destFile, ovv);
                   // Result.Set(context, true);

                }
                else if(tval == 0)
                {
                    if (System.IO.Directory.Exists(sourcePath))
                    {
                        string[] files = System.IO.Directory.GetFiles(sourcePath);

                        foreach (string s in files)
                        {
                            if (replace == true)
                            {
                               
                                fileName = System.IO.Path.GetFileName(s);
                                fileloop:
                                string destFile = System.IO.Path.Combine(targetPath, fileName);
                                
                                if(System.IO.File.Exists(destFile))
                                {
                                    destFile = System.IO.Path.Combine(targetPath, "Copy-" + fileName);
                                    fileName = "Copy-" + fileName;
                                    goto fileloop;
                                }
                                else
                                {
                                    System.IO.File.Copy(s, destFile, false);
                                }
                                
                                Result.Set(context, true);
                            }
                            else
                            {
                                fileName = System.IO.Path.GetFileName(s);
                                string destFile = System.IO.Path.Combine(targetPath, fileName);
                                if(ovv==true)
                                {
                                    System.IO.File.Copy(s, destFile, ovv);
                                    Result.Set(context, true);
                                }
                                else
                                {try
                                    {
                                        System.IO.File.Copy(s, destFile, ovv);
                                        Result.Set(context, true);
                                    }
                                    catch
                                    {
                                        Result.Set(context, false);
                                    }
                                    
                                }
                                
                            }
                            
                        }
                    }
                    else
                    {
                        Result.Set(context, false);
                    }
                }
                else
                {
                    Result.Set(context, false);
                } 
            }
            else if (oval == 1)
            {
                if (tval == 1)
                {
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    //string destFile = System.IO.Path.Combine(targetPath, fileName);
                    if (replace == true)
                    {
                        fileName = System.IO.Path.GetFileName(sourceFile);
                    fileloop1:
                        string destFile = System.IO.Path.Combine(targetPath, fileName);

                        if (System.IO.File.Exists(destFile))
                        {
                            destFile = System.IO.Path.Combine(targetPath, "Copy-" + fileName);
                            fileName = "Copy-" + fileName;
                            goto fileloop1;
                        }
                        else
                        {
                            if (System.IO.File.Exists(sourceFile))
                            {
                                System.IO.File.Move(sourceFile, destFile);
                                Result.Set(context, true);
                            }
                            else
                            {
                                //System.IO.File.Move(sourceFile, destFile);
                                Result.Set(context, false);
                            }
                        }

                        //Result.Set(context, true);
                    }
                    else
                    {
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        if (ovv == true)
                        {
                            if (System.IO.File.Exists(sourceFile))
                            { 
                                if (System.IO.File.Exists(destFile))
                                {
                                    System.IO.File.Delete(destFile);
                                }
                                System.IO.File.Move(sourceFile, destFile);
                                Result.Set(context, true);
                            }
                            else
                            {
                                Result.Set(context, false);
                            }
                        }


                        else if (ovv == false)
                        {
                            try
                            {
                                System.IO.File.Move(sourceFile, destFile);
                                Result.Set(context, true);
                            }
                            catch
                            {
                                Result.Set(context, false);
                            }
                        }
                    }
                    //System.IO.File.Move(sourceFile, destFile);
                    //Result.Set(context, true);
                }
                else if (tval == 0)
                {
                    if (System.IO.Directory.Exists(sourcePath))
                    {
                        string[] files = System.IO.Directory.GetFiles(sourcePath);

                        foreach (string s in files)
                        {
                            fileName = System.IO.Path.GetFileName(s);
                            string destFile = System.IO.Path.Combine(targetPath, fileName);
                            System.IO.File.Move(s, destFile);
                            Result.Set(context, true);
                        }
                    }
                    else
                    {
                        Result.Set(context, false);
                    }
                }
                else
                {
                    Result.Set(context, false);
                } 
            }  
        }
    }
}
