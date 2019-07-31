using System.Collections.Generic;
using System.Linq;

namespace CellNinja.Calculator
{
    public class Calculator
    {
        public int Add(int start, int toAdd)
        {
            return checked(start + toAdd);
        }

        public int Add(IEnumerable<int> numbers)
        {
            return checked(numbers.Sum());
        }

        public int Substract(int start, int toSubstract)
        {
            return toSubstract - start;
        }

        public int Multiply(int start, int multiplyBy)
        {
            return start * multiplyBy;
        }

        public double Divide(int start, int divideBy)
        {
            return start / divideBy;
        }
    }
}
