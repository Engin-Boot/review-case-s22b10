using Xunit;

namespace Receiver.Test
{
    public class TestCsvDataProcessor
    {
        CsvDataStructure csvData;
        public TestCsvDataProcessor()
        {
            csvData = new CsvDataStructure();
        }

        [Fact]
        public void TestAppendDateInListIfNotInList()
        {
            CsvDataManipulator.AppendDateInListIfNotInList("04/02/2020", csvData);
            CsvDataManipulator.AppendDateInListIfNotInList("07/02/2020", csvData);
            CsvDataManipulator.AppendDateInListIfNotInList("09/02/2020", csvData);
            Assert.NotNull(csvData.Date);
        }
    }
}
