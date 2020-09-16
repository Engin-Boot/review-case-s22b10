using System.IO;
using System;
using System.Text;

namespace Receiver.Test
{
    class ReceiverTestUtility
    {
        public static string GetDummyCsvPathReceiver(string csvFileName)
        {
            string path = Directory.GetCurrentDirectory();
            var directoryInfo = Directory.GetParent(path).Parent;
            if (directoryInfo != null)
                return Path.Combine(directoryInfo.Parent.FullName, csvFileName);
            return null;
        }
        public static string CreateDummyCsvReceiver(string csvFileName)
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
            var filepath = GetDummyCsvPathReceiver(csvFileName);
            File.WriteAllText(filepath, sb.ToString());
            return filepath;
        }
        public static StringWriter ConsolerReaderForTest()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            return output;
        }
    }
}
