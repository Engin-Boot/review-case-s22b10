using System.IO;
using System.Text;
using static System.Console;

namespace sender.tests
{
    public static class Utility
    {
        private static string GetDummyCsvPath(string csvFileName)
        {
            string path = Directory.GetCurrentDirectory();
            var directoryInfo = Directory.GetParent(path).Parent;
            if (directoryInfo != null)
            {
                if (directoryInfo.Parent != null)
                    return Path.Combine(directoryInfo.Parent.FullName, csvFileName);
                return null;
            }
            else
            {
                return null;
            }
        }
        public static string CreateDummyCsv(string csvFileName)
        {
            string delimeter = ",";
            var output = new[]
            {
                   new[]{ "ReviewDate", "Comments"},
                   new[]{ "4/28/2020  10:14:00 AM", "Comment1"},
                   new[]{ "4/27/2020  9:14:00 AM", "Comment2"}
            };
            var length = output.GetLength(0);
            var sb = new StringBuilder();
            for (int index = 0; index < length; index++)
                sb.AppendLine(string.Join(delimeter, output[index]));
            var filepath = GetDummyCsvPath(csvFileName);
            File.WriteAllText(filepath, sb.ToString());
            return filepath;
        }
        public static void RemoveCsvFile(string csvFileName)
        {
            var csvpath = GetDummyCsvPath(csvFileName);
            if (!File.Exists(csvpath)) return;
            File.Delete(csvpath);
        }
        public static StreamReader CreateStreamReaderDummyCsv(string csvFileName)
        {
            return new StreamReader(GetDummyCsvPath(csvFileName));
        }

        public static StringWriter ConsolerReaderForTest()
        {
            var output = new StringWriter();
            SetOut(output);
            return output;
        }

        public static string CreateEmptyCsv(string fileName)
        {
            var filePath = GetDummyCsvPath(fileName);
            try
            {
                File.Create(filePath).Close();
                return filePath;
            }
            catch (IOException)
            {
                return null;
            }
        }
        
    }
}
