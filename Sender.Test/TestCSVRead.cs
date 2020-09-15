using System.IO;
using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    public class TestCSVRead
    {
        [Fact]
        public void TestWriteWordOnConsoleWithNoColFilter()
        {
            CSVReader csvread = new CSVReader();
            var filename = "testcsvreader.csv";
            CreateDummyCSV(filename);
            StreamReader sr = CreateStreamReaderDummyCSV(filename);
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr);
            string expected_result = "4/28/2020  10:14:00 AM Comment1 \r\n4/27/2020  9:14:00 AM Comment2 \r\n";
            Assert.Equal(expected_result, output.ToString());
        }
        [Fact]
        public void TestWriteWordOnConsoleWithColFilter()
        {
            CSVReader csvread = new CSVReader();
            var filename = "testcsvreader.csv";
            CreateDummyCSV(filename);
            StreamReader sr = CreateStreamReaderDummyCSV(filename);
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr, "0");
            string expected_result = "4/28/2020  10:14:00 AM 4/27/2020  9:14:00 AM ";
            Assert.Equal(expected_result, output.ToString());
        }
        [Fact]
        public void TestWriteWordOnConsoleForNoColData()
        {
            CSVReader csvread = new CSVReader();
            var filename = "testcsvreader.csv";
            CreateDummyCSV(filename);
            StreamReader sr = CreateStreamReaderDummyCSV(filename);
            var output = ConsolerReaderForTest();
            csvread.WriteWordOnConsole(sr, "2");
            string expected_result = "";
            Assert.Equal(expected_result, output.ToString());
        }
        ~TestCSVRead()
        {
            RemoveCSVFile("testcsvreader.csv");
        }
    }

    
}
