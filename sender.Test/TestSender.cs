using System;
using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    [Collection("Sender")]
    public class TestSender: IDisposable
    {
        [Fact]
        public void TestMainInvalidCsvFileName()
        {
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { "" });
            var expected_result = "2(0xF)";
            Assert.Equal(expected_result, output.ToString());
            output.Close();
        }

        [Fact]
        public void TestMainInvalidColumnNumber()
        {
            var csvFile = CreateDummyCsv("test-sender.csv");
            var expectedResult = "2(0xA)";
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { csvFile, "invalid" });
            Assert.Equal(expectedResult, output.ToString());
            output.Close();
        }
        public void Dispose()
        {
            RemoveCsvFile("test-sender.csv");
        }
    }
}
