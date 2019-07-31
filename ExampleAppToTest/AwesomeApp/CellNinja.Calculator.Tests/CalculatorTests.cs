using System;
using System.Collections.Generic;
using Xunit;

namespace CellNinja.Calculator.Tests
{
    public class CalculatorTest
    {
        private Calculator calculator;

        public CalculatorTest()
        {
            calculator = new Calculator();
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(-1, 1, 0)]
        [InlineData(Int32.MinValue, Int32.MaxValue, -1)]
        [InlineData(Int32.MinValue, 1, -2147483647)]
        [InlineData(Int32.MaxValue, -1, 2147483646)]
        public void Add_TwoNumbers_ShouldReturnSum(int first, int second, int expected)
        {
            //Act
            var result = calculator.Add(first, second);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, Int32.MaxValue)]
        [InlineData(Int32.MaxValue, 1)]
        [InlineData(Int32.MaxValue, Int32.MaxValue)]
        [InlineData(-1, Int32.MinValue)]
        [InlineData(Int32.MinValue, -1)]
        [InlineData(Int32.MinValue, Int32.MinValue)]
        public void Add_OneAndMaxValue_ShouldThrowOverflowException(int first, int second)
        {
            //Act
            Action action = () => calculator.Add(first, second);

            //Assert
            Assert.Throws<OverflowException>(action);
        }

        public static IEnumerable<object[]> ListOfNumbers =>
            new List<object[]>
            {
                new object[] { new List<int> { 1, 1, 1 }, 3 },
                new object[] { new List<int> { -1, -1, -1 }, -3 },
                new object[] { new List<int> { -1, 1, -1 }, -1 },
                new object[] { new List<int> { 0, -0, 0 }, 0 },
                new object[] { new List<int> { Int32.MinValue, 0, 0 }, Int32.MinValue },
                new object[] { new List<int> { Int32.MinValue, 1, -1 }, Int32.MinValue },
            };

        [Theory]
        [MemberData(nameof(ListOfNumbers))]
        public void Add_ListOfNumbers_ShouldReturnSum(IEnumerable<int> numbers, int expected)
        {
            //Act
            var result = calculator.Add(numbers);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
