using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Test")]
namespace sender
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            StreamReader stream_reader = null;
            try
            {
                var csv_path = args[0];
                stream_reader = new StreamReader(csv_path);
            }
            catch (Exception)
            {
                Console.Write("2(0xF)");
                return;
            }
            CSVReader reader = new CSVReader();
            if (args.Length <= 1)
            {
                reader.WriteWordOnConsole(stream_reader);
            }
            else
            {
                reader.WriteWordOnConsole(stream_reader, args[1]);
            }
            stream_reader.Close();
        }
    }
}
