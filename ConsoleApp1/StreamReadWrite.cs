using System;
using System.IO;

namespace ConsoleApp1
{
    
    public class StreamReadWrite
    {
        public StreamReader StreamReturnObject(string fileName)
        {
            
            try
            {
                StreamReader sr = new StreamReader(fileName);
                return sr;
            }
            catch(Exception)
            {
                Console.WriteLine("Error: Unable to read or write file");
                Environment.Exit(0);
                return null;
            }
            
                
            }
    }
}
