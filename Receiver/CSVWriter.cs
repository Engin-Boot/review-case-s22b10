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
                        writer.WriteLine("{0},{1},{2}", item.Key, item.Value.wordCount, entry);
                    }
                }
            }
        }
    }
}
