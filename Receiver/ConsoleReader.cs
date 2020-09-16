using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    class ConsoleReader
    {
        readonly StreamReadWrite srw = new StreamReadWrite();
        public Dictionary<string, CsvDataStructure> Reader(string filePath)
        {
            var fileContent = new Dictionary<string, CsvDataStructure>(); ;
            if (Utility.CreateFile(filePath))
            {
                var sr = srw.StreamReturnObject(filePath);
                fileContent = Utility.ReadFromFile(sr, fileContent);
            }
            fileContent = Utility.ReadFromConsole(fileContent);
            return fileContent;
        }
    }
}
