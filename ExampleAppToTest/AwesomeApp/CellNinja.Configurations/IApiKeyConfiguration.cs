using System.Collections.Generic;

namespace CellNinja.Configurations
{
    public interface IApiKeyConfiguration
    {
        IEnumerable<KeyValuePair<string, string>> ApiKeys { get; }
    }
}
