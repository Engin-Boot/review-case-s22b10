using System;
using System.IO;

namespace sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            CSVReader reader = new CSVReader();
            StreamReader stream_reader = reader.CSV_Reader(Constants.csv_path);
            if (stream_reader != null)
            {
                reader.WriteWordOnConsole(stream_reader);
            }

            Console.ReadKey();
        }
    }
}
