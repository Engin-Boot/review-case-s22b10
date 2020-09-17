﻿using System.Collections.Generic;
using Xunit;
using static Receiver.Test.ReceiverTestUtility;

namespace Receiver.Test
{
    public class TestCSVWriter
    {
        [Fact]
        public void TestWriteOnCSV()
        {
            CsvWriter writer = writer = new CsvWriter();
            string fileName = "TestWriteOnCSV.csv";
            string filePath = CreateTestFileAndReturnFilePath(fileName);
            Dictionary<string, CsvDataStructure> data = new Dictionary<string, CsvDataStructure>();
            data.Add("view", ReturnClassObject("2"));
            data.Add("delete", ReturnClassObject("9"));
            data.Add("rename", ReturnClassObject("78"));
            data.Add("forget", ReturnClassObject("34"));
            writer.WriteOnCSV(filePath, data);
            Dictionary<string, CsvDataStructure> fileContent = ReadInDicFromCsv(filePath);
            Assert.Equal(ToAssertableString(data), ToAssertableString(fileContent));
        }
    }
}
