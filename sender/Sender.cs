﻿using System;
using System.IO;

namespace sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            StreamReader stream_reader = null;
            try
            {
                var csv_path = args[0];
                stream_reader = new StreamReader(csv_path);
            }
            catch (Exception)
            {
                throw new Exception("Invalid File Name");
            }
            CSVReader reader = new CSVReader();
            Console.WriteLine(args.Length);
            if (args.Length <= 1)
            {
                reader.WriteWordOnConsole(stream_reader);
            }
            else
            {
                reader.WriteWordOnConsole(stream_reader, args[1]);
            }
        }
    }
}