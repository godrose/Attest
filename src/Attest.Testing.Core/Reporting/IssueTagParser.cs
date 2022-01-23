using System.Collections.Generic;

namespace Attest.Testing.Reporting
{
    /// <summary>
    /// The issue tag parser.
    /// </summary>
    public class IssueTagParser
    {
        /// <summary>
        /// The default issue id.
        /// </summary>
        public const int DefaultIssueId = default;
        private const string TagPrefix = "@";
        private readonly string _issueTag;

        /// <summary>
        /// Creates an instance of <see cref="IssueTagParser" />.
        /// </summary>
        /// <param name="reportConfigurationProvider"></param>
        public IssueTagParser(ReportConfigurationProvider reportConfigurationProvider)
        {
            ResolveValue(out var tagIssueSeparator, reportConfigurationProvider.TagIssueSeparator, Consts.DefaultTagIssueSeparator);
            ResolveValue(out var tagIssuePrefix, reportConfigurationProvider.TagIssuePrefix, Consts.DefaultTagIssuePrefix);
            _issueTag = TagPrefix + tagIssuePrefix + tagIssueSeparator;
        }

        /// <summary>
        /// Searches for an issue id in the collection of specified tags.
        /// </summary>
        /// <param name="tags">The collection of tags</param>
        /// <returns>The id of the first matching issue, default value otherwise.</returns>
        public int GetIssueIdFromTags(IEnumerable<string> tags)
        {
            var issueId = DefaultIssueId;
            foreach (var tag in tags)
            {
                issueId = GetIssueIdFromTag(tag);
                if (issueId != DefaultIssueId)
                {
                    return issueId;
                }
            }

            return issueId;
        }

        /// <summary>
        /// Extracts an issue id from the specified tag.
        /// </summary>
        /// <param name="tag">The specified tag.</param>
        /// <returns>The id of the issue, default value otherwise.</returns>
        public int GetIssueIdFromTag(string tag)
        {
            if (tag.StartsWith(_issueTag))
            {
                var issueId = int.Parse(tag.Substring(_issueTag.Length));
                return issueId;
            }

            return default;
        }

        /// <summary>
        /// Builds tag from the specified issue id.
        /// </summary>
        /// <param name="issueId">The issue id.</param>
        /// <returns></returns>
        public string BuildTagFromIssueId(int issueId)
        {
            return $"{_issueTag}{issueId}";
        }

        private static void ResolveValue(out string field, string value, string defaultValue)
        {
            field = value;
            if (string.IsNullOrWhiteSpace(field))
            {
                field = defaultValue;
            }
        }
    }
}
