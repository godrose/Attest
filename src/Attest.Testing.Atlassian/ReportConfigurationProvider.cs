using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Atlassian
{
    public class ReportConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ReportConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string TagIssuePrefix => GetReportSection().GetSection(nameof(TagIssuePrefix)).Value;

        public string TagIssueSeparator => GetReportSection().GetSection(nameof(TagIssueSeparator)).Value;

        private IConfigurationSection GetReportSection()
        {
            return _configuration.GetSection("Report");
        }
    }
}