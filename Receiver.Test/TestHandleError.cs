using Xunit;

using  static Receiver.Test.ReceiverTestUtility;

namespace Receiver.Test
{
    public class TestHandleError
    {
        [Fact]
        public void ConsolerReaderToTestReciverWithErrorCode()
        {
            var output = ConsolerReaderToTestReciver();
            HandleError.IfErrorLogInConsole("2(0xA)");
            Assert.Equal("Error: Invalid column argument\r\n", output.ToString());
            output.Close();
        }
        [Fact]
        public void TestErrorLogInConsoleWithNoErrorCode()
        {
            var output = ConsolerReaderToTestReciver();
            HandleError.IfErrorLogInConsole("");
            Assert.Equal("", output.ToString());
            output.Close();
        }
    }
}
