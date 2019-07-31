using System.Collections.Generic;

namespace CellNinja.Configurations
{
    public class ApiKeyConfiguration : IApiKeyConfiguration
    {
        public ApiKeyConfiguration(IEnumerable<KeyValuePair<string, string>> apiKeys)
        {
            ApiKeys = apiKeys;
        }

        public IEnumerable<KeyValuePair<string, string>> ApiKeys { get; }
    }
}
