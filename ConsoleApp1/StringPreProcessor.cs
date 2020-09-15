using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApp1;

namespace ConsoleApp1
{
    class StringPreProcessor
    {
        public static bool IsValidString(string word, string stringOnly)
        {
            if (!StringPreProcessor.RemoveStopWord(word)
                            && stringOnly.Length != 0 && !StringPreProcessor.CheckStringIsDate(word))
                return true;
            return false;
        }
        public static bool CheckStringIsDate(string date)
        {
            DateTime dateValue;
            return DateTime.TryParse(date, out dateValue);
        }
        public static string ReturnStringIfStringIsDate(string date)
        {

            if (CheckStringIsDate(date))
                return date;
            else
                return "";
        }
        public static string RemoveSymbolsAndReturnString(string word)
        {
            StringBuilder stringOnly = new StringBuilder();
            foreach (char letter in word)
            {
                if ((letter >= '0' && letter <= '9') ||
                    (letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z')
                    || letter == '.' || letter == '_' || letter == '-')
                {
                    stringOnly.Append(letter);
                }
            }
            return stringOnly.ToString().ToLower();
        }
        public static bool RemoveStopWord(string word)
        {
            StreamReadWrite srw = new StreamReadWrite();
            string filePath = "C:\\Users\\320089145\\trainging\\ConsoleApp1\\ConsoleApp1\\bin\\Debug\\stopwords.csv";
            if (File.Exists(filePath))
            {
                StreamReader sr = srw.StreamReturnObject(filePath);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    if (words[0].Contains(word))
                    {
                        sr.Close();
                        return true;
                    }
                }
                sr.Close();
            }
            return false;
        }
    }
}
