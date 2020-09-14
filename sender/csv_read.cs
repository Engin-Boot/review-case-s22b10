using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

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
                else
                    WriteWordOnConsoleWithColumnFilter(comment_string, col_filter);
                }
            }   

        private string[] SplitRowBasedOnSeperator(string row, char seperator)
        {
        if (row.Contains(seperator))
        {
            return row.Split(seperator);
        }
        else
        {
            return new []{ row };
        }
        }
        private void WriteWordOnConsoleNoColumnFilter(string[] comment)
        {
            for (var column = 0; column < comment.Length; column++)
            {
                Console.Write(comment[column] + " ");
            }
        }

        private void WriteWordOnConsoleWithColumnFilter(string[] comment, string col_filter_string)
        {
            try
            {   
                var col_filter = int.Parse(col_filter_string);
                Console.Write(comment[col_filter] + " ");
            }
            catch (IndexOutOfRangeException)
            {
                // skip the row
            }
            catch(FormatException)
            {
                throw new Exception("Error: Invalid column argument");
            }
        }
        
    }
}
