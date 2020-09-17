using System;
using Xunit;
using static sender.tests.Utility;

namespace sender.tests
{
    [Collection("Sender")]
    public class TestCsvRead : IDisposable
    {
        readonly CsvReader _csvread;
        public TestCsvRead()
        {
            _csvread = new CsvReader();
        }
        [Fact]
        public void TestWriteWordOnConsoleWithNoColFilter()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr);
            var expected_result = "4/28/2020  10:14:00 AM Comment1 \n4/27/2020  9:14:00 AM Comment2 \n";
            Assert.Equal(expected_result, (string) output.ToString());
            output.Close();
        }
        [Fact]
        public void TestWriteWordOnConsoleWithColFilter()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr, "0");
            var expected_result = "4/28/2020  10:14:00 AM 4/27/2020  9:14:00 AM ";
            Assert.Equal(expected_result, (string) output.ToString());
            output.Close();
        }
        [Fact]
        public void TestWriteWordOnConsoleForNoColData()
        {
            var filename = "testcsvreader.csv";
            CreateDummyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filename);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr, "2");
            const string expectedResult = "";
            Assert.Equal((string) expectedResult, (string) output.ToString());
            output.Close();
        }
        [Fact]
        public void TestTestWriteWordOnConsoleForNoColDataWithNoSeperator()
        {
            var filename = "testcsvreader.csv";
            var filePath = CreateEmptyCsv(filename);
            using var sr = CreateStreamReaderDummyCsv(filePath);
            var output = ConsolerReaderForTest();
            _csvread.WriteWordOnConsole(sr, "2");
            const string expectedResult = "";
            Assert.Equal((string) expectedResult, (string) output.ToString());
            output.Close();
        }
        public void Dispose()
        {
            RemoveCsvFile("testcsvreader.csv");
        }
    }
}
