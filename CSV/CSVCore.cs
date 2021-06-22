using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class CSVCore
    {
        internal static List<string> ReadCSV(string FilePath, int columnnumber, bool includeheader, char delimiter)
        {
            string[] Lines = File.ReadAllLines(FilePath);
            int row = 1;
            List<string> Contents = new List<string>();
            foreach (var line in Lines)
            {
                var counts = line.Split(delimiter);
                foreach (var count in counts)
                {
                    if (row / columnnumber == 1)
                    {
                        Contents.Add(count);
                        break;
                    }
                    else
                    {
                        row += 1;
                    }
                }
                row = 1;
            }
            if (includeheader == false)
            {
                Contents.RemoveAt(0);
            }
            return Contents;
        }
        internal static void WriteCSV(string FilePath, List<string> Text)
        {
            StreamWriter stream = new StreamWriter(FilePath);
            foreach (var text in Text)
            {
                stream.WriteLine(text);
            }
            stream.Close();
        }
        internal static void AppendCSV(string FilePath, List<string> Text)
        {
            StreamWriter stream = new StreamWriter(FilePath, true);
            foreach (var text in Text)
            {
                stream.WriteLine(text);
            }
            stream.Close();
        }
    }
}
