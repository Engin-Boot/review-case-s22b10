using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace sender
{
    public class CSVReader
    {
        internal StreamReader CSV_Reader(string csv_name)
        {
            try
            {
                return new StreamReader(csv_name);
            }
            catch
            {
                Console.WriteLine("ERROR: Unable to read CSV file. Please check file path and permission of the file");
                return null;
            }
        }
        internal void WriteWordOnConsole(StreamReader reader, [Optional] int col_filter)
        {
            reader.ReadLine();      // Remove title of columns
            char separatingChar = ',';
            while (!reader.EndOfStream)
            {
                var row = reader.ReadLine();
                if (row.Contains(separatingChar))
                {
                    var comment_string = row.Split(separatingChar);
                    WriteWordOnConsoleBasedOnColumnFilter(comment_string, col_filter);
                }
            }
        }
        private void WriteWordOnConsoleBasedOnColumnFilter(string[] comment, int col_filter)
        {
            if (col_filter == 0)
            {
                // Filtering on column is not applied
                for (var column = 0; column < comment.Length; column++)
                {
                    Console.Write(comment[column] + " ");
                }
            }
            else
            {
                try
                {
                    Console.Write(comment[col_filter]);
                }
                catch (IndexOutOfRangeException)
                {
                    // skip the row
                }

            }

        }
    }
}
