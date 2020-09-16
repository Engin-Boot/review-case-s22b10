using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Receiver
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
                        writer.WriteLine("{0},{1}", item.Key, item.Value.wordCount);
                }
            }
        }
    }
}
