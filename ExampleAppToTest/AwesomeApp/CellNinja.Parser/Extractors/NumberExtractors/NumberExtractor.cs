using System.Collections.Generic;
using System.Linq;

namespace CellNinja.Parser.Extractors
{
    public class NumberExtractor : INumberExtractor
    {
        public IEnumerable<int> GetIntegers(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return Enumerable.Empty<int>();
            }

            if (!numbers.Contains(","))
            {
                return new List<int> { int.Parse(numbers) };
            }

            return numbers
                .Split(",")
                .Select(s => int.Parse(s))
                .ToList();
        }
    }
}


