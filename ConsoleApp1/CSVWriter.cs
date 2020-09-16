using System.Collections.Generic;
using System.Text;
using System.IO;

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
                        dateList.AppendLine(string.Join(",", entry));
                    }
                    writer.Write("{0},{1},{2}", item.Key, item.Value.wordCount, dateList);
                }
            }
        }
    }
}
