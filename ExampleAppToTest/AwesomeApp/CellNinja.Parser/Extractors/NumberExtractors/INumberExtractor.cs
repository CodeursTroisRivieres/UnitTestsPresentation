using System.Collections.Generic;

namespace CellNinja.Parser.Extractors
{
    public interface INumberExtractor
    {
        IEnumerable<int> GetIntegers(string numbers);
    }
}
