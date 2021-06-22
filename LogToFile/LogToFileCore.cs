using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LogToFile
{
    class LogToFileCore
    {
        internal static void CreateLog(string Path,string Message)
        {
            StreamWriter stream;
            if (!File.Exists(Path))
            {
                stream = new StreamWriter(Path);
            }
            else
            {
                stream = File.AppendText(Path);
            }
            stream.WriteLine($"{DateTime.Now.ToString()} : {Message}");
            stream.Close();
        }
    }
}
