using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Receiver.Test.ReceiverTestUtility;
namespace Receiver.Test
{
    public class TestHandleError
    {
        [Fact]
        public void ConsolerReaderForTestWithErrorCode()
        {
            var output = ReceiverConsolerReaderForTest();
            HandleError.IfErrorLogInConsole("2(0xA)");
            Assert.Equal("Error: Invalid column argument\r\n", output.ToString());
            output.Close();
        }
        [Fact]
        public void TestErrorLogInConsoleWithNoErrorCode()
        {
            var output = ReceiverConsolerReaderForTest();
            HandleError.IfErrorLogInConsole("");
            Assert.Equal("", output.ToString());
            output.Close();
        }
    }
}
