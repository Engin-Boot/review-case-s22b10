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
        internal void WriteOnCSV(string filePath, Dictionary<string, CSVDataStructure> fileContent)
        {
            StringBuilder wordAndWordCount = new StringBuilder();
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var item in fileContent)
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
            System.IO.File.WriteAllText(filePath, wordAndWordCount.ToString());
        }
    }
}
