using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Receiver.Test
{
    public class TestUtility
    {
        [Fact]
        public void TestCreateFile()
        {
            string fileName = "TestCreateFile.csv";
            bool isFileCreated = Utility.CreateFile(fileName);
            string currDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currDir, fileName);
            if(File.Exists(filePath))
                Assert.True(isFileCreated);
            else
                Assert.True(isFileCreated);
        }

        [Fact]
        public void TestReadFromFile()
        {
            string fileName = "TestReadFromFile.csv";
            StreamReader sr = new StreamReader(fileName);
            Dictionary<string, CsvDataStructure> fileContent = new Dictionary<string, CsvDataStructure>();
            Dictionary<string, CsvDataStructure> output = Utility.ReadFromFile(sr, fileContent);
            Assert.NotEmpty(output);
        }
    }
}
