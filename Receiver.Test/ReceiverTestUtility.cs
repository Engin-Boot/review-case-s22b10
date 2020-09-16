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
        public static string GetDummyCsvPath(string csvFileName)
        {
            string path = Directory.GetCurrentDirectory();
            var directoryInfo = Directory.GetParent(path).Parent;
            if (directoryInfo != null)
                return Path.Combine(directoryInfo.Parent.FullName, csvFileName);
            return null;
        }
        public static void RemoveCsvFile(string csvFileName)
        {
            var csvpath = GetDummyCsvPath(csvFileName);
            if (!File.Exists(csvpath)) return;
            File.Delete(csvpath);
        }
    }
}
