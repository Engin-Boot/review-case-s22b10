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
        public StreamReader StreamReturnObject(string filename)
        {
            
            try
            {
                StreamReader sr = new StreamReader(filename);
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
