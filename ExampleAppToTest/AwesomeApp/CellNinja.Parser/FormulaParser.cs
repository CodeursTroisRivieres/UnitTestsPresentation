using System.Collections.Generic;
using System.Linq;

namespace CellNinja.Parser
{
    public class FormulaParser
    {
        public IList<FormulaElement> GetElements(string formula)
        {

            return Enumerable.Empty<FormulaElement>().ToList();
        }
    }

    public class PlusElement : OperandElement
    {
        public override string ToString()
        {
            return "+";
        }
    }

    public abstract class OperandElement : FormulaElement
    {
    }

    public abstract class FormulaElement
    {
    }
}
