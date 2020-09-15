﻿using System;
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
            (StreamReader sr, Dictionary<string,CSVDataStructure> fileContent)
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                try
                {
                    CSVDataManipulator.AddDataInList(words[0], words[1],"",fileContent);
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
                            CSVDataManipulator.AddDataInList(stringOnly, "1", date,fileContent);
                        }
                        catch (ArgumentException)
                        {
                            var mapedObj = fileContent[stringOnly];
                            mapedObj.wordCount = (int.Parse(mapedObj.wordCount) + 1).ToString();
                            CSVDataManipulator.AppendDateInListIfNotInList(date);
                            fileContent[stringOnly] = mapedObj;
                        }
                    }
                }
            }
            return fileContent;
        }
    }
}