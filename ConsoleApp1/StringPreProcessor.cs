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
        private static bool IsStringIsNull(string word)
        {
            return (word.Length == 0);
        }
        public static bool IsValidString(string word, string stringOnly)
        {
            bool isStopWord = RemoveStopWord(word);
            bool isDate = CheckStringIsDate(word);
            bool isStringNull = IsStringIsNull(word);
            if (isStopWord == isDate == isStringNull == false)
                return true;
            return false;
        }
        private static bool CheckStringIsDate(string date)
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
        private static bool IsDigit(char letter)
        {
            return (letter >= '0' && letter <= '9');
        }
        private static bool IsAlphabet(char letter)
        {
            return ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'));
        }
        private static bool IsSymbol(char letter)
        {
            return (letter == '.' || letter == '_' || letter == '-');
        }
        public static string RemoveSymbolsAndReturnString(string word)
        {
            StringBuilder stringOnly = new StringBuilder();
            foreach (char letter in word)
            {
                bool isDigit = IsDigit(letter);
                bool isAlphabet = IsAlphabet(letter);
                bool isSymbol = IsSymbol(letter);
                if (isDigit || isAlphabet || isSymbol )
                {
                    stringOnly.Append(letter);
                }
            }
            return stringOnly.ToString().ToLower();
        }
        private static bool RemoveStopWord(string word)
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
