using System;
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

            throw new NotImplementedException();
        }
    }
}


