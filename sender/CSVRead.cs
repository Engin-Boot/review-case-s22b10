using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("sender.Test")]
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
                int columnName;
                try
                {
                    columnName = int.Parse(col_filter);
                }
                catch(FormatException)
                {
                    Console.Write("2(0xA)");
                    return;
                }
                WriteWordOnConsoleWithColumnFilter(reader, columnName);
            }
            
            reader.Close();
        }

        internal string[] SplitRowBasedOnSeperator(string row, char seperator)
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
                var commentString = SplitRowBasedOnSeperator(row, ',');
                for (var column = 0; column < commentString.Length; column++)
                {
                    Console.Write(commentString[column] + " ");
                }
                Console.WriteLine();
            }
        }

        private void WriteWordOnConsoleWithColumnFilter(StreamReader reader, int col_filter)
        {
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                var comment_string = SplitRowBasedOnSeperator(row, ',');
                try
                {
                    Console.Write(comment_string[col_filter] + " ");
                }
                catch (IndexOutOfRangeException)
                {
                    //Skip the row
                }
            }
        }
    }
}
