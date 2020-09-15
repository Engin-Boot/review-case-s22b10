using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Sdk;
using static sender.Test.Utility;

namespace sender.Test
{
    public class TestCSVRead
    {
        [Fact]
        public void TestWriteWordOnConsoleWithNoColFilter()
        {
            CSVReader csvread = new CSVReader();
            StreamReader sr = CreateStreamReaderDummyCSV("testcsvreader.csv");
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr);
            string expected_result = "4/28/2020  10:14:00 AM Comment1 \r\n4/27/2020  9:14:00 AM Comment2 \r\n";
            Assert.Equal(expected_result, output.ToString());
        }
        [Fact]
        public void TestWriteWordOnConsoleWithColFilter()
        {
            CSVReader csvread = new CSVReader();
            string csvpath = CreateDummyCSV("testcsvreader.csv");
            StreamReader sr = CreateStreamReaderDummyCSV("testcsvreader.csv");
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr, "0");
            string expected_result = "4/28/2020  10:14:00 AM 4/27/2020  9:14:00 AM ";
            Assert.Equal(expected_result, output.ToString());
        }
        [Fact]
        ~TestCSVRead()
        {
            RemoveCSVFile("testcsvreader.csv");
        }
    }

    
}
