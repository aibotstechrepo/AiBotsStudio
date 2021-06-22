using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace File_Operations
{
    public static class FileOperations
    {
        public static class FileOpearations
        {
            /// <summary>
            /// Function to create a new file 
            /// </summary>
            /// <param name="FilePath">Path where the file has to be created</param>
            public static void FileCreate(string FilePath)
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                File.Create(FilePath);
            }

            /// <summary>
            /// Function to open an existing file/ create a new file
            /// </summary>
            /// <param name="FilePath">Path where the file to open or create</param>
            public static void FileOpen(string FilePath)
            {
                if (File.Exists(FilePath) == true)
                {
                    File.Open(FilePath, FileMode.Open);
                }
                else
                {
                    File.Open(FilePath, FileMode.OpenOrCreate);
                }
            }

            /// <summary>
            /// Function to check if file exists at path
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <returns>boolean of file exists or not</returns>
            public static bool FileExists(string FilePath)
            {
                return File.Exists(FilePath);
            }

            /// <summary>
            /// Function to read the contents of file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <returns>string containing the contents of the file</returns>
            public static string FileRead(string FilePath)
            {
                return File.ReadAllText(FilePath);
            }

            /// <summary>
            /// Function to read the contents of file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <returns>array of string which contains line by line contents of the file </returns>
            public static string[] FileReadLines(string FilePath)
            {
                return File.ReadAllLines(FilePath);
            }

            /// <summary>
            /// Function to write to a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <param name="Content">Contents to be written to file</param>
            /// <param name="Append">Append content to file</param>
            public static void FileWrite(string FilePath, string Content, bool Append)
            {
                StreamWriter stream;
                if (!File.Exists(FilePath))
                {
                    stream = new StreamWriter(FilePath);
                }
                else
                {
                    stream = File.AppendText(FilePath);
                }
                if (Append == true)
                {
                    stream.Write(Content);
                }
                else
                {
                    stream.WriteLine(Content);
                }
                stream.Close();
            }

            /// <summary>
            /// Function to write line by line contents to a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <param name="Contents">Contents(string array) to be written to file</param>
            public static void FileWriteLines(string FilePath, string[] Contents)
            {
                File.WriteAllLines(FilePath, Contents);
            }

            /// <summary>
            /// Function To Encrypt a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            public static void FileEncrypt(string FilePath)
            {
                File.Encrypt(FilePath);
            }

            /// <summary>
            /// Function To Decrypt a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            public static void FileDecrypt(string FilePath)
            {
                File.Decrypt(FilePath);
            }

            /// <summary>
            /// Function to get attribute of a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <returns>returns a string equivalence of file attribute</returns>
            public static string FileGetAttribute(string FilePath)
            {
                return File.GetAttributes(FilePath).ToString();
            }

            /// <summary>
            /// Function to change/set the attribute of a file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <param name="attribute">Attribute to set to file</param>
            public static void FileSetAttribute(string FilePath, int attribute)
            {
                if (attribute == 1)
                {
                    File.SetAttributes(FilePath, FileAttributes.Normal);
                }
                else if (attribute == 2)
                {
                    File.SetAttributes(FilePath, FileAttributes.ReadOnly);
                }
                else if (attribute == 3)
                {
                    File.SetAttributes(FilePath, FileAttributes.Hidden);
                }
            }

            /// <summary>
            /// Function to get creation/access time of file
            /// </summary>
            /// <param name="FilePath">Path where the file exists</param>
            /// <param name="Type">creation/access</param>
            /// <param name="UTC">true or false</param>
            /// <returns></returns>
            public static string FileGetTime(string FilePath, string Type, bool UTC)
            {
                if (Type.Contains("creation"))
                {
                    if (UTC == true)
                        return File.GetCreationTimeUtc(FilePath).ToString();
                    else
                        return File.GetCreationTime(FilePath).ToString();
                }
                else if (Type.Contains("access"))
                {
                    if (UTC == true)
                        return File.GetLastAccessTimeUtc(FilePath).ToString();
                    else
                        return File.GetLastAccessTime(FilePath).ToString();
                }
                else
                {
                    if (UTC == true)
                        return File.GetLastWriteTimeUtc(FilePath).ToString();
                    else
                        return File.GetLastWriteTime(FilePath).ToString();
                }
            }

            /// <summary>
            /// Function to replace contents of specified file with contents of another file
            /// </summary>
            /// <param name="SourceFile"></param>
            /// <param name="DestinationFile"></param>
            /// <param name="BackupFile"></param>
            public static void FileReplace(string SourceFile, string DestinationFile, string BackupFile)
            {
                if (File.Exists(SourceFile) == true)
                {
                    File.Replace(SourceFile, DestinationFile, BackupFile);
                }
            }

            /// <summary>
            /// Function to get list of files present in folder
            /// </summary>
            /// <param name="FolderPath"></param>
            /// <param name="FileType"></param>
            /// <returns></returns>
            public static string[] FileList(string FolderPath, string FileType)
            {
                if (Directory.Exists(FolderPath))
                {
                    string[] Files;
                    if (FileType.Trim() == "")
                    {
                        Files = Directory.GetFiles(FolderPath);
                    }
                    else
                    {
                        Files = Directory.GetFiles(FolderPath, FileType);
                    }
                    return Files;
                }
                else
                {
                    return null;
                }
            }

            /// <summary>
            /// Function to copy or move a file from one location to another
            /// </summary>
            /// <param name="SourcePath"></param>
            /// <param name="DestinationPath"></param>
            /// <param name="Operation"></param>
            /// <param name="Override"></param>
            /// <returns></returns>
            public static bool FileCopyMove(string SourcePath, string DestinationPath, string Operation, bool Override)
            {
                if (File.Exists(SourcePath))
                {
                    if (Operation.ToLower() == "copy")
                    {
                        if (Override == false)
                        {
                            File.Copy(SourcePath, DestinationPath);
                            return true;
                        }
                        else
                        {
                            File.Copy(SourcePath, DestinationPath, true);
                            return true;
                        }
                    }
                    else
                    {
                        File.Move(SourcePath, DestinationPath);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
