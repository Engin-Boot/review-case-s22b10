using System;
using Xunit;
using static sender.tests.Utility;

namespace sender.tests
{
    [Collection("Sender")]
    public class TestSender: IDisposable
    {
        [Fact]
        public void TestMainInvalidCsvFileName()
        {
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { "" });
            var expectedResult = "2(0xF)";
            Assert.Equal(expectedResult, (string) output.ToString());
            output.Close();
        }

        [Fact]
        public void TestMainInvalidColumnNumber()
        {
            var csvFile = CreateDummyCsv("test-sender.csv");
            var expectedResult = "2(0xA)";
            var output = ConsolerReaderForTest();
            Sender.Main(new[] { csvFile, "invalid" });
            Assert.Equal(expected: expectedResult, (string) output.ToString());
            output.Close();
        }
        public void Dispose() => RemoveCsvFile("test-sender.csv");
    }
}
