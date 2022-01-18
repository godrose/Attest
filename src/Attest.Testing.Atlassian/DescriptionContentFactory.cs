using Attest.Testing.Atlassian.Models;
using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian
{
    public class DescriptionContentFactory
    {
        private readonly AtlassianConfigurationProvider _atlassianConfigurationProvider;

        public DescriptionContentFactory(AtlassianConfigurationProvider atlassianConfigurationProvider)
        {
            _atlassianConfigurationProvider = atlassianConfigurationProvider;
        }

        public DescriptionContent Create(JObject issue)
        {
            var desc = issue["fields"]["description"];
            var mainContent = desc["content"] as JArray;
            return new DescriptionContent(
                _atlassianConfigurationProvider,
                mainContent);
        }
    }
}
