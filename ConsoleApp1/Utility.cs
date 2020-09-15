using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Utility
    {
        public static bool CreateFile(string fileName)
        {
            string curDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(curDir, fileName);
            if (!File.Exists(fileName))
            {
                File.Create(filePath).Close();
                return false;
            }
            return true;
        } 
        public static Dictionary<string, CSVDataStructure> ReadFromFile
            (StreamReader sr, string filepath, Dictionary<string,CSVDataStructure> file_content)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                try
                {
                    CSVDataManipulator.AddDataInList(words[0], words[1],"",file_content);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error while reading the file");
                }
            }
            sr.Close();
            return file_content;
        }
        public static Dictionary<string, CSVDataStructure> ReadFromConsole
            (Dictionary<string, CSVDataStructure> file_content)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (HandleError.IfErrorLogInConsole(line))
                {
                    break;
                }
                String[] words= line.Split();
                string date = StringPreProcessor.ReturnStringIfStringIsDate(words[0]); 
                foreach (string word in words)
                {
                    string stringOnly = StringPreProcessor.RemoveSymbolsAndReturnString(word);
                    if (StringPreProcessor.IsValidString(word, stringOnly))
                    {
                        try
                        {
                            CSVDataManipulator.AddDataInList(stringOnly, "1", date,file_content);
                        }
                        catch (ArgumentException)
                        {
                            var MapedObj = file_content[stringOnly];
                            MapedObj.wordCount = (int.Parse(MapedObj.wordCount) + 1).ToString();
                            CSVDataManipulator.AppendDateInListIfNotInList(date);
                            file_content[stringOnly] = MapedObj;
                        }
                    }
                }
            }
            return file_content;
        }
    }
}