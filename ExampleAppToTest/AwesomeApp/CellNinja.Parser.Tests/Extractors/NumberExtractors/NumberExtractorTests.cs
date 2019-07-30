using System.Collections.Generic;
using CellNinja.Parser.Extractors;
using Xunit;

namespace CellNinja.Parser.Tests
{
    public class NumberExtractorTests
    {
        [Fact]
        public void GetIntegers_EmptyString_ShouldReturnEmptyList()
        {
            //Arrange
            NumberExtractor extractor = new NumberExtractor();
            string numbers = string.Empty;

            //Act
            var result = extractor.GetIntegers(numbers);

            //Assert
            var expected = new List<int>();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetIntegers_Null_ShouldReturnEmptyList()
        {
            //Arrange
            NumberExtractor extractor = new NumberExtractor();
            string numbers = null;

            //Act
            var result = extractor.GetIntegers(numbers);

            //Assert
            var expected = new List<int>();
            Assert.Equal(result, expected);
        }

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

        //[Theory]
        //public void GetIntegers_CommaSeparatedNumbersAsString_ShouldReturnListWithNumbers(string input, IEnumerable<int> result)
        //{
        //    //Arrange
        //    NumberExtractor extractor = new NumberExtractor();
        //    string numbers = "1,2,3";

        //    //Act
        //    var result = extractor.GetIntegers(numbers);

        //    //Assert
        //    var expected = new List<int> { 1, 2, 3 };
        //    Assert.Equal(result, expected);
        //}
    }
}
