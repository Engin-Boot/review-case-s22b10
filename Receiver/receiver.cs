using System.Collections.Generic;

namespace ConsoleApp1
{
    class Receiver
    {
        public static void Main()
        {
            ConsoleReader reader = new ConsoleReader();
            Dictionary<string, CSVDataStructure> fileContent = reader.Reader("output.csv");
            CSVWriter csvwrite = new CSVWriter();
            csvwrite.WriteOnCSV
                ("output.csv", fileContent);
        }
    }
}
