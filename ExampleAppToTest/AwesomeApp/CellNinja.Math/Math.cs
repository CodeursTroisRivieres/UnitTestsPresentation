using System.Collections.Generic;
using System.Linq;

namespace CellNinja.Math
{
    public class Math
    {
        public int Add(int start, int toAdd)
        {
            return start + toAdd;
        }

        public int Add(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public int Substract(int start, int toSubstract)
        {
            return start - toSubstract;
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
