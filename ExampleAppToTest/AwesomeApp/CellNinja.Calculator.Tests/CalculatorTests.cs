using System;
using FluentAssertions;
using Xunit;

namespace CellNinja.Calculator.Tests
{
    public class CalculatorTests : IDisposable
    {
        private Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]
        [InlineData(Int32.MinValue, 1, -2147483647)]
        public void Add_OneAndOne_ShouldReturnTwo(int first, int second, int expected)
        {
            //Arrange

            //Act
            var result = _calculator.Add(first, second);

            //Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Add_MaxValuePlusOne_ShouldThrowOverflowException()
        {
            //Arrange

            //Act
            Action action = () => _calculator.Add(Int32.MaxValue, 1);

            //Assert
            action.Should().Throw<OverflowException>();
        }

        public void Dispose()
        {
            _calculator = null;
        }
    }
}
