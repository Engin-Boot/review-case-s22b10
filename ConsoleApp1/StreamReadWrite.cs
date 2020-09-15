using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
