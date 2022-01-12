using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Atlassian
{
    public class AtlassianConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public AtlassianConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl => GetAtlassianSection().GetSection("BaseUrl").Value;

        public string IssuePrefix =>
            GetAtlassianSection().GetSection("Jira").GetSection("IssuePrefix").Value;

        public int StatusPageId => int.Parse(GetAtlassianSection().GetSection("Confluence")
            .GetSection("StatusPageId").Value);

        private IConfigurationSection GetAtlassianSection()
        {
            return _configuration.GetSection("Atlassian");
        }
    }
}