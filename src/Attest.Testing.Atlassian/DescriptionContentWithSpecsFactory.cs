using Attest.Testing.Atlassian.Models;

namespace Attest.Testing.Atlassian
{
    public class DescriptionContentWithSpecsFactory
    {
        private readonly AtlassianConfigurationProvider _atlassianConfigurationProvider;

        public DescriptionContentWithSpecsFactory(AtlassianConfigurationProvider atlassianConfigurationProvider)
        {
            _atlassianConfigurationProvider = atlassianConfigurationProvider;
        }

        public DescriptionContentWithSpecs Create(Issue issue)
        {
            return new DescriptionContentWithSpecs(
                _atlassianConfigurationProvider,
                issue.Description.Content);
        }
    }
}
