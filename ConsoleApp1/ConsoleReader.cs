using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class ConsoleReader
    {
        StreamReadWrite srw = new StreamReadWrite();
        public Dictionary<string, CSVDataStructure> Reader(string filePath)
        {
            var file_content = new Dictionary<string, CSVDataStructure>(); ;
            if (Utility.CreateFile(filePath))
            {
                StreamReader sr = srw.StreamReturnObject(filePath);
                file_content = Utility.ReadFromFile(sr, file_content);
            }
            file_content = Utility.ReadFromConsole(file_content);
            return file_content;

        }


    }
}
