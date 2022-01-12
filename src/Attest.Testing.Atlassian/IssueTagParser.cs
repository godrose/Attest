using System.Collections.Generic;

namespace Attest.Testing.Atlassian
{
    public class IssueTagParser
    {
        internal const int DefaultIssueId = default;
        private const string TagPrefix = "@";
        private readonly string _issueTag;

        public IssueTagParser(ReportConfigurationProvider reportConfigurationProvider)
        {
            ResolveValue(out var tagIssueSeparator, reportConfigurationProvider.TagIssueSeparator, Consts.DefaultTagIssueSeparator);
            ResolveValue(out var tagIssuePrefix, reportConfigurationProvider.TagIssuePrefix, Consts.DefaultTagIssuePrefix);
            _issueTag = TagPrefix + tagIssuePrefix + tagIssueSeparator;
        }

        public int GetIssueIdFromTags(IEnumerable<string> tags)
        {
            const int defaultIssueId = default;
            var issueId = defaultIssueId;
            foreach (var tag in tags)
            {
                issueId = GetIssueIdFromTag(tag);
                if (issueId != defaultIssueId)
                {
                    return issueId;
                }
            }

            return issueId;
        }

        public int GetIssueIdFromTag(string tag)
        {
            if (tag.StartsWith(_issueTag))
            {
                var issueId = int.Parse(tag.Substring(_issueTag.Length));
                return issueId;
            }

            return default;
        }

        private void ResolveValue(out string field, string value, string defaultValue)
        {
            field = value;
            if (string.IsNullOrWhiteSpace(field))
            {
                field = defaultValue;
            }
        }
    }
}
