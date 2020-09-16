using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    class ConsoleReader
    {
        StreamReadWrite srw = new StreamReadWrite();
        public Dictionary<string, CSVDataStructure> Reader(string filePath)
        {
            var fileContent = new Dictionary<string, CSVDataStructure>(); ;
            if (Utility.CreateFile(filePath))
            {
                StreamReader sr = srw.StreamReturnObject(filePath);
                fileContent = Utility.ReadFromFile(sr, fileContent);
            }
            fileContent = Utility.ReadFromConsole(fileContent);
            return fileContent;

        }


    }
}
