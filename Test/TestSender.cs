using System;
using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    [Collection("Sender")]
    public class TestSender: IDisposable
    {
        
        [Fact]
        public void TestMainInvalidCSVFileName()
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
            string csv_file = CreateDummyCSV("test-sender.csv");
            string expected_result = "2(0xA)";
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { csv_file, "invalid" });
            Assert.Equal(expected_result, output.ToString());
            output.Close();
        }
        public void Dispose()
        {
            RemoveCSVFile("test-sender.csv");
        }
    }
}
