using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;

namespace ConsoleApp1
{
    class CSVWriter
    {
        internal void WriteOnCSV(string filepath, Dictionary<string, CSVDataStructure> file_content)
        {
            StringBuilder wordAndWordCount = new StringBuilder();
            using (var writer = new StreamWriter(filepath))
            {
                foreach (var item in file_content)
                {
                    StringBuilder dateList = new StringBuilder();
                    foreach (var entry in item.Value.date)
                    {
                        dateList.AppendLine(string.Join(",",entry));
                    }
                    var dataFormat = string.Format("{0},{1},{2}", item.Key, item.Value.wordCount, dateList);
                    wordAndWordCount.AppendLine(dataFormat);
                }
            }
            System.IO.File.WriteAllText(filepath, wordAndWordCount.ToString());
        }
    }
}
