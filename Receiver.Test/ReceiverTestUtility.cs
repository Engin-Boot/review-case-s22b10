using System.IO;
using System;

namespace Receiver.Test
{
    class ReceiverTestUtility
    {
        public static void CreateFile(string fileName)
        {
            string curDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(curDir, fileName);
        }
        public static StringWriter ConsolerReaderForTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            return output;
        }
    }
}
