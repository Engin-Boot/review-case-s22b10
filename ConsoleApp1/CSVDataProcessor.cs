using System.Collections.Generic;

namespace ConsoleApp1
{
    public class CSVDataStructure
    {
        public string wordCount { get; set; }
        public List<string> date = new List<string>();
    }
    public class CSVDataManipulator
    {
        public static void AppendDateInListIfNotInList(string date)
        {
            CSVDataStructure csvObj = new CSVDataStructure();
            foreach (var enter in csvObj.date)
            {
                if (enter == date)
                {
                    return;
                }
            }
            csvObj.date.Add(date);
        }
        internal static void AddDataInList(string word, string wordCount, string date,
            Dictionary<string, CSVDataStructure> file_contents)
        {
            CSVDataStructure listObj = new CSVDataStructure();
            listObj.date.Add(date);
            listObj.wordCount = wordCount;
            file_contents.Add(word, listObj);
        }
    }

}
