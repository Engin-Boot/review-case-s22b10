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
            
            if (col_filter == null)
                    WriteWordOnConsoleNoColumnFilter(reader);
            else
            {
                WriteWordOnConsoleWithColumnFilter(reader, col_filter);
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
        private void WriteWordOnConsoleNoColumnFilter(StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var comment_string = SplitRowBasedOnSeperator(row, ',');
                for (var column = 0; column < comment_string.Length; column++)
                {
                    Console.Write(comment_string[column] + " ");
                }
                Console.WriteLine();
            }
        }

        private bool WriteWordOnConsoleWithColumnFilter(StreamReader reader, string col_filter_string)
        {
            bool isValidColumn = true;
            try
            {
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine();
                    var comment_string = SplitRowBasedOnSeperator(row, ',');
                    var col_filter = int.Parse(col_filter_string);
                    Console.Write(comment_string[col_filter] + " ");
                }
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
