using System.Text;
using System.IO;
using System;

namespace sender.Test
{
    class Utility
    {
        public static string getDummyCSVPath(string csv_file_name)
        {
            string path = Directory.GetCurrentDirectory();
            return Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, csv_file_name);
        }
        public static string CreateDummyCSV(string csv_file_name)
        {
            string delimeter = ",";
            string[][] output = new string[][]{
                   new string[]{ "ReviewDate", "Comments"},
                   new string[]{ "4/28/2020  10:14:00 AM", "Comment1"},
                   new string[]{ "4/27/2020  9:14:00 AM", "Comment2"}
            };
            int length = output.GetLength(0);
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimeter, output[index]));

            var filepath = getDummyCSVPath(csv_file_name);
            File.WriteAllText(filepath, sb.ToString());
            return filepath;
        }
        public static void RemoveCSVFile(string csv_file_name)
        {
            var csvpath = getDummyCSVPath(csv_file_name);
            if (File.Exists(csvpath))
            {
                File.Delete(csvpath);
            }
        }
        public static StreamReader CreateStreamReaderDummyCSV(string csv_file_name)
        {
            return new StreamReader(getDummyCSVPath(csv_file_name));
        }

        public static StringWriter ConsolerReaderForTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            return output;
        }
        
    }
}
