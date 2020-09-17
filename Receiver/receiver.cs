using System.Collections.Generic;

namespace Receiver
{
    class Receiver
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            Dictionary<string, CsvDataStructure> fileContent = reader.Reader("output.csv");
            var csvWrite = new CsvWriter();
            csvWrite.WriteOnCSV
                ("output.csv", fileContent);
        }
    }
}
