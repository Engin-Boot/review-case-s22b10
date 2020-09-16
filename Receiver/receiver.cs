using System.Collections.Generic;

namespace Receiver
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
