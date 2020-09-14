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
                if (row.Contains(separatingChar))
                {
                    var comment_string = row.Split(separatingChar);
                    if (col_filter == null)
                        WriteWordOnConsoleNoColumnFilter(comment_string);
                    else
                        WriteWordOnConsoleColumnFilter(comment_string, col_filter);
                }
            }
        }

        private void WriteWordOnConsoleNoColumnFilter(string[] comment)
        {
            for (var column = 0; column < comment.Length; column++)
            {
                Console.Write(comment[column] + " ");
            }
        }

        private void WriteWordOnConsoleColumnFilter(string[] comment, string col_filter_string)
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
