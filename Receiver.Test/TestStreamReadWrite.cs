using System.IO;
using Xunit;

namespace Receiver.Test
{
    [Collection("Receiver")]
    public class TestStreamReadWrite 
    {
        StreamReadWrite SReadWrite;
        public TestStreamReadWrite()
        {
            SReadWrite = new StreamReadWrite();
        }
        [Fact]
        public void TestStreamReturnObject()
        {
            string fileName = "text.txt";
            bool isFileExist = File.Exists(fileName);
            StreamReader sr = SReadWrite.StreamReturnObject(fileName);
            Assert.Null(sr);
        }
    }
}
