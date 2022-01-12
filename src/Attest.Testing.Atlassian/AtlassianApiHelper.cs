namespace Attest.Testing.Atlassian
{
    public class AtlassianApiHelper
    {
        private readonly AtlassianConfigurationProvider _atlassianConfigurationProvider;

        public AtlassianApiHelper(AtlassianConfigurationProvider atlassianConfigurationProvider)
        {
            _atlassianConfigurationProvider = atlassianConfigurationProvider;
        }

        public string BuildIssueResourceId(int issueId)
        {
            var resourceId = _atlassianConfigurationProvider.IssuePrefix + Consts.JiraIssueSeparator + issueId;
            return resourceId;
        }
    }
}