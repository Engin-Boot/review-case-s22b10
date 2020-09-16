using System;
using System.IO;
using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    [Collection("Sender")]
    public class TestCSVRead : IDisposable
    {
        readonly CSVReader csvread;
        public TestCSVRead()
        {
            csvread = new CSVReader();
        }
        [Fact]
        public void TestWriteWordOnConsoleWithNoColFilter()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr);
            string expected_result = "4/28/2020  10:14:00 AM Comment1 \r\n4/27/2020  9:14:00 AM Comment2 \r\n";
            Assert.Equal(expected_result, output.ToString());
            output.Close();
        }
        [Fact]
        public void TestWriteWordOnConsoleWithColFilter()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using (var sr = CreateStreamReaderDummyCsv(filename))
            {
                var output = ConsolerReaderForTest();
                csvread.WriteWordOnConsole(sr, "0");
                string expected_result = "4/28/2020  10:14:00 AM 4/27/2020  9:14:00 AM ";
                Assert.Equal(expected_result, output.ToString());
                output.Close();
            }
        }
        [Fact]
        public void TestWriteWordOnConsoleForNoColData()
        {
            
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using StreamReader sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr, "2");
            string expected_result = "";
            Assert.Equal(expected_result, output.ToString());
            output.Close();
        }
        [Fact]
        public void TestSplitRowBasedOnSeperatorWithNoSeperator()
        {
            string[] expectedResult = { "" };
            string[] actualResult = csvread.SplitRowBasedOnSeperator("", ',');
            Assert.Equal(expectedResult, actualResult);
        }
        public void Dispose()
        {
            RemoveCsvFile("testcsvreader.csv");
        }
    }
}
