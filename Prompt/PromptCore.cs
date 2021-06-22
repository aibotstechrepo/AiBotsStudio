using System;
using System.IO;
using System.Drawing;
using System.Security;

namespace Prompt
{
    public class PromptCore
    {
        internal static string PromptSelectFile()
        {
            //System.Windows.Forms.OpenFileDialog DialogBox = new System.Windows.Forms.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog DialogBox = new Microsoft.Win32.OpenFileDialog();
            DialogBox.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            DialogBox.Title = "Phoenix Studio (Select File)";
            DialogBox.Filter = "Text Files (*.txt)|*.txt" + "|" + "PDF Files (*.pdf)|*.pdf" + "|" + "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" + "All Files (*.*)|*.*";
            DialogBox.ShowDialog();
            DialogBox.RestoreDirectory = true;
            return DialogBox.FileName;
        }
        internal static string PromptSelectFolder()
        {
            //System.Windows.Forms.FolderBrowserDialog DialogBox = new System.Windows.Forms.FolderBrowserDialog();
            //DialogBox.ShowNewFolderButton = true;
            //DialogBox.RootFolder = Environment.SpecialFolder.MyComputer;
            //DialogBox.Description = "--------------Phoenix Studio--------------\n\n\tSelect The Desired Folder";
            //DialogBox.ShowDialog();
            //return DialogBox.SelectedPath;

            Microsoft.Win32.OpenFileDialog DialogBox = new Microsoft.Win32.OpenFileDialog();
            DialogBox.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            DialogBox.Title = "Select The Desired Folder";
            DialogBox.CheckPathExists = true;
            DialogBox.CheckFileExists = false;
            DialogBox.ShowDialog();
            DialogBox.RestoreDirectory = true;
            string FolderName = DialogBox.FileName;
            int limit = FolderName.LastIndexOf(Convert.ToChar(@"\"));
            FolderName = FolderName.Substring(0, limit);
            return FolderName;
        }
    }
}
