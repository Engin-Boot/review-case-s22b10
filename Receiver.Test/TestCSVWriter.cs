using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;
using static Receiver.Test.ReceiverTestUtility;

namespace Receiver.Test
{
    public class TestCSVWriter
    {
        CsvWriter writer;
        public TestCSVWriter()
        {
            writer = new CsvWriter();
        }
        
        [Fact]
        public void TestWriteOnCSV()
        {
            string fileName = "TestWriteOnCSV.csv";
            string filePath = CreateTestFileAndReturnFilePath(fileName);
            Dictionary<string, CsvDataStructure> data = new Dictionary<string, CsvDataStructure>();
            data.Add("view", ReturnClassObject("2"));
            data.Add("delete", ReturnClassObject("9"));
            data.Add("rename", ReturnClassObject("78"));
            data.Add("forget", ReturnClassObject("34"));
            writer.WriteOnCSV(filePath, data);
            Dictionary<string, CsvDataStructure> fileContent;
            fileContent = ReadInDicFromCsv(filePath);

            Assert.Equal(ToAssertableString(data), ToAssertableString(fileContent));
        }
    }
}
