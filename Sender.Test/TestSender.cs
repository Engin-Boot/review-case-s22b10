using Xunit;
using static sender.Test.Utility;

namespace sender.Test
{
    public class TestSender
    {
        
        [Fact]
        public void TestMainInvalidCSVFileName()
        {
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { "" });
            var expected_result = "2(0xF)";
            Assert.Equal(expected_result, output.ToString());
        }

        [Fact]
        public void TestMainInvalidColumnNumber()
        {
            
            string csv_file = CreateDummyCSV("testsender.csv");
            string expected_result = "2(0xA)";
            var output = ConsolerReaderForTest();
            Sender.Main(new string[] { csv_file, "invalid" });
            Assert.Equal(expected_result, output.ToString());

        }
        ~TestSender()
        {
            Utility.RemoveCSVFile("testsender.csv");
        }
    }
}
