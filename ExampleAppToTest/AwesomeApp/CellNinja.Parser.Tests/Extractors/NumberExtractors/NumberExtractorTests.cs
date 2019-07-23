using System.Collections.Generic;
using CellNinja.Parser.Extractors;
using Xunit;

namespace CellNinja.Parser.Tests
{
    public class NumberExtractorTests
    {
        [Fact]
        public void GetIntegers_OneAsString_ShouldReturnListWithOne()
        {
            //Arrange
            NumberExtractor extractor = new NumberExtractor();
            string numbers = "1";

            //Act
            var result = extractor.GetIntegers(numbers);

            //Assert
            var expected = new List<int> { 1 };
            Assert.Equal(result, expected);
        }
    }
}
