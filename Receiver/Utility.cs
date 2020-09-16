using System;
using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    internal class Utility
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
            (StreamReader sr, Dictionary<string,CSVDataStructure> fileContent)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                try
                {
                    CSVDataManipulator.AddDataInList(words[0], words[1],words[2],fileContent);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error while reading the file");
                }
            }
            sr.Close();
            return fileContent;
        }
        public static Dictionary<string, CSVDataStructure> ReadFromConsole
            (Dictionary<string, CSVDataStructure> fileContent)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                HandleError.IfErrorLogInConsole(line);
                String[] words= line.Split();
                string date = StringPreProcessor.ReturnStringIfStringIsDate(words[0]); 
                foreach (string word in words)
                {
                    string stringOnly = StringPreProcessor.RemoveSymbolsAndReturnString(word);
                    bool isStringValid = StringPreProcessor.IsValidString(word, stringOnly);
                    if (isStringValid)
                    {
                        try
                        {
                            CSVDataManipulator.AddDataInList(stringOnly, "1", date,fileContent);
                        }
                        catch (ArgumentException)
                        {
                            var mapedObj = fileContent[stringOnly];
                            mapedObj.wordCount = (int.Parse(mapedObj.wordCount) + 1).ToString();
                            CSVDataManipulator.AppendDateInListIfNotInList(date, mapedObj);
                            fileContent[stringOnly] = mapedObj;
                        }
                    }
                }
            }
            return fileContent;
        }
    }
}
