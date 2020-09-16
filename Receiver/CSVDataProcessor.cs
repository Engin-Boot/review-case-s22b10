using System.Collections.Generic;

namespace Receiver
{
    public class CSVDataStructure
    {
        public string wordCount { get; set; }
        public List<string> date = new List<string>();
    }
    public class CSVDataManipulator
    {
        public static void AppendDateInListIfNotInList(string date,  CSVDataStructure csvObj)
        {
            foreach (var enter in csvObj.date)
            {
                if (enter == date == true)
                {
                    return;
                }
            }
            csvObj.date.Add(date);
        }
        public static void AddDataInList(string word, string wordCount, string date,
            Dictionary<string, CSVDataStructure> fileContent)
        {
            CSVDataStructure listObj = new CSVDataStructure();
            listObj.date.Add(date);
            listObj.wordCount = wordCount;
            fileContent.Add(word, listObj);
        }
    }

}
