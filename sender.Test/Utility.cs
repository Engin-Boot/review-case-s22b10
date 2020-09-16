using System.Text;
using System.IO;
using System;

namespace sender.Test
{
    class Utility
    {
        public static string GetDummyCsvPath(string csvFileName)
        {
            string path = Directory.GetCurrentDirectory();
            return Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, csvFileName);
        }
        public static string CreateDummyCsv(string csvFileName)
        {
            string delimeter = ",";
            var output = new string[][]{
                   new string[]{ "ReviewDate", "Comments"},
                   new string[]{ "4/28/2020  10:14:00 AM", "Comment1"},
                   new string[]{ "4/27/2020  9:14:00 AM", "Comment2"}
            };
            int length = output.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimeter, output[index]));
            var filepath = GetDummyCsvPath(csvFileName);
            File.WriteAllText(filepath, sb.ToString());
            return filepath;
        }
        public static void RemoveCsvFile(string csvFileName)
        {
            var csvpath = GetDummyCsvPath(csvFileName);
            if (File.Exists(csvpath))
            {
                File.Delete(csvpath);
            }
        }
        public static StreamReader CreateStreamReaderDummyCsv(string csvFileName)
        {
            return new StreamReader(GetDummyCsvPath(csvFileName));
        }

        public static StringWriter ConsolerReaderForTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            return output;
        }
        
    }
}
