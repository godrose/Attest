using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Reporting
{
    /// <summary>
    /// The report configuration provider.
    /// </summary>
    public class ReportConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Creates an instance of <see cref="ReportConfigurationProvider" />.
        /// </summary>
        /// <param name="configuration"></param>
        public ReportConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the tag issue prefix from the configuration.
        /// </summary>
        public string TagIssuePrefix => GetReportSection().GetSection(nameof(TagIssuePrefix)).Value;

        /// <summary>
        /// Gets the tag issue separator from the configuration.
        /// </summary>
        public string TagIssueSeparator => GetReportSection().GetSection(nameof(TagIssueSeparator)).Value;

        private IConfigurationSection GetReportSection()
        {
            return _configuration.GetSection("Report");
        }
    }
}