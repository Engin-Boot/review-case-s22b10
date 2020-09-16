using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Receiver.Test.ReceiverTestUtility;

namespace Receiver.Test
{
    public class TestConsoleReader
    {
        ConsoleReader reader;

        public TestConsoleReader()
        {
            reader = new ConsoleReader();
        }
        [Fact]
        public void TestReader()
        {
            /*Dictionary<string, CsvDataStructure> wordAndWordCount = new Dictionary<string, CsvDataStructure>();
            string fileName = "TestConsoleReader.csv";
            string filePath = CreateDummyCsv(fileName);
            wordAndWordCount = reader.Reader(filePath);
            Assert.NotNull(wordAndWordCount);*/
        }
    }
}
