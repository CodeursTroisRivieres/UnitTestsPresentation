using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CellNinja.Math.Tests
{
    public class MathTests
    {
        public static IEnumerable<object[]> AddData =>
            new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { 0, 0, 0 },
            };

        [Theory]
        [MemberData(nameof(AddData))]
        //[InlineData(1, 2, 3)]
        //[InlineData(0, 0, 0)]
        //[InlineData(1, -1, 0)]
        //[InlineData(-1, -2, -3)]
        //[InlineData(-1, 1, 0)]
        //[InlineData(-10, -10, -20)]
        //[InlineData(int.MinValue, 1, -2147483647)]
        public void Add_OneAndTwo_ShouldBeThree(int start, int toAdd, int expected)
        {
            //Arrange
            Math math = new Math();

            //Act
            var result = math.Add(start, toAdd);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Substract_TwoAndOne_ShouldBeOne()
        {
            //Arrange
            Math math = new Math();

            //Act
            var result = math.Substract(2, 1);

            //Assert
            result.Should().Be(3);
        }
    }
}
