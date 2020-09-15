using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("Test")]
namespace sender
{
    public class CSVReader
    {
        internal void WriteWordOnConsole(StreamReader reader, [Optional] string col_filter)
        {
            reader.ReadLine();      // Remove title of columns
            char separatingChar = ',';
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var comment_string = SplitRowBasedOnSeperator(row, separatingChar);
                if (col_filter == null)
                    WriteWordOnConsoleNoColumnFilter(comment_string);
                else if (!WriteWordOnConsoleWithColumnFilter(comment_string, col_filter))
                    break;
            }
            reader.Close();
        }

        private string[] SplitRowBasedOnSeperator(string row, char seperator)
        {
            if (row.Contains(seperator))
            {
                return row.Split(seperator);
            }
            return new[] { "" };
        }
        private void WriteWordOnConsoleNoColumnFilter(string[] comment)
        {
            for (var column = 0; column < comment.Length; column++)
            {
                Console.Write(comment[column] + " ");
            }
            Console.WriteLine();
        }

        private bool WriteWordOnConsoleWithColumnFilter(string[] comment, string col_filter_string)
        {
            bool isValidColumn = true;
            try
            {
                var col_filter = int.Parse(col_filter_string);
                Console.Write(comment[col_filter] + " ");
            }
            catch (IndexOutOfRangeException)
            {
                // skip the row
            }
            catch (FormatException)
            {
                isValidColumn = false;
                Console.Write("2(0xA)");
            }
            return isValidColumn;
        }
    }
}
