using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("sender.Test")]
namespace sender
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            StreamReader streamReader;
            try
            {
                var csvPath = args[0];
                streamReader = new StreamReader(csvPath);
            }
            catch (Exception)
            {
                Console.Write("2(0xF)");
                return;
            }
            CSVReader reader = new CSVReader();
            if (args.Length <= 1)
            {
                reader.WriteWordOnConsole(streamReader);
            }
            else
            {
                reader.WriteWordOnConsole(streamReader, args[1]);
            }
            streamReader.Close();
        }
    }
}
