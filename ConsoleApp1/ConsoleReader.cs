using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConsoleReader
    {
        StreamReadWrite srw = new StreamReadWrite();
        public Dictionary<string, CSVDataStructure> Reader(string file_path)
        {
            var file_content = new Dictionary<string, CSVDataStructure>(); ;
            if (Utility.CreateFile(file_path))
            {
                StreamReader sr = srw.StreamReturnObject(file_path);
                file_content = Utility.ReadFromFile(sr, file_path, file_content);
            }
            file_content = Utility.ReadFromConsole(file_content);
            return file_content;

        }


    }
}
