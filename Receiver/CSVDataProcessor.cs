using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class CsvDataStructure
    {
        public string WordCount { get; set; }
        public List<string> Date = new List<string>();
    }

    public class CsvDataManipulator
    {
        public static void AppendDateInListIfNotInList(string date, CsvDataStructure csvObj)
        {
            if (csvObj.Date.Any(enter => enter == date == true))
            {
                return;
            }
            csvObj.Date.Add(date);
        }

        public static void AddDataInList(string word, string wordCount, string date,
            Dictionary<string, CsvDataStructure> fileContent)
        {
            var listObj = new CsvDataStructure();
            listObj.Date.Add(date);
            listObj.WordCount = wordCount;
            fileContent.Add(word, listObj);
        }
    }
}
