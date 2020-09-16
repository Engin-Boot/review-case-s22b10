using System.Collections.Generic;
using System.Linq;

namespace Receiver
{
    public class CSVDataStructure
    {
        public string WordCount { get; set; }
        public List<string> date = new List<string>();
    }

    public class CSVDataManipulator
    {
        public static void AppendDateInListIfNotInList(string date, CSVDataStructure csvObj)
        {
            if (csvObj.date.Any(enter => enter == date == true))
            {
                return;
            }

            csvObj.date.Add(date);
        }

        public static void AddDataInList(string word, string wordCount, string date,
            Dictionary<string, CSVDataStructure> fileContent)
        {
            var listObj = new CSVDataStructure();
            listObj.date.Add(date);
            listObj.WordCount = wordCount;
            fileContent.Add(word, listObj);
        }
    }
}
