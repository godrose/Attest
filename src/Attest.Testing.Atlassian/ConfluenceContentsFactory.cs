using System;
using System.Collections.Generic;
using System.Text;
using Attest.Testing.Atlassian.Models;
using Attest.Testing.Execution;
using Attest.Testing.Execution.Models;

namespace Attest.Testing.Atlassian
{
    public sealed class ConfluenceContentsFactory
    {
        private const string TagPrefix = "@";
        private const string TagIssueSeparator = "-";
        private const string TagIssuePrefix = "BDD";
        private readonly ConfluenceProvider _confluenceProvider;
        private readonly JiraProvider _jiraProvider;
        private readonly AtlassianApiHelper _atlassianApiHelper;
        private readonly ISpecsInfo _specsInfo;
        private readonly string _jiraIssuePrefix;
        private readonly string _issueTag;
        private readonly string _baseUrl;

        public ConfluenceContentsFactory(
            ConfluenceProvider confluenceProvider,
            JiraProvider jiraProvider,
            AtlassianConfigurationProvider atlassianConfigurationProvider,
            AtlassianApiHelper atlassianApiHelper,
            ISpecsInfo specsInfo)
        {
            _confluenceProvider = confluenceProvider;
            _jiraProvider = jiraProvider;
            _atlassianApiHelper = atlassianApiHelper;
            _specsInfo = specsInfo;
            _jiraIssuePrefix = TagIssuePrefix + TagIssueSeparator;
            _issueTag = TagPrefix + _jiraIssuePrefix;
            _baseUrl = atlassianConfigurationProvider.BaseUrl;
        }

        public IEnumerable<object> BuildContents(int pageId, string env)
        {
            foreach (var node in _specsInfo.FeatureData.Nodes)
            foreach (var folder in node.Folders)
                yield return BuildContent(pageId, _specsInfo.TestExecution.ExecutionResults, folder,
                    _specsInfo.TestExecution.ExecutionTime, env);
        }

        private object BuildContent(
            int pageId,
            IEnumerable<ExecutionResult> executionResults,
            Folder folder,
            DateTime executionTime,
            string env)
        {
            var scenarioRows = new List<string>();

            foreach (var fold in folder.Folders)
            foreach (var feature in fold.Features)
            foreach (var result in executionResults)
                if (feature.Title == result.FeatureTitle)
                    foreach (var scenario in feature.ScenarioDefinitions)
                        if (scenario.Title == result.ScenarioTitle)
                        {
                            var ticket = ExtractTicket(scenario.Tags);
                            var issue = GetIssueIdFromTags(scenario.Tags);
                            if (issue != default)
                                if (_jiraProvider.IsIssueIncludedInTheCurrentSprint(issue))
                                {
                                    var scenarioRow = BuildScenarioRow(executionResults, scenario.Title, ticket);
                                    scenarioRows.Add(scenarioRow);
                                }
                        }

            var versionNumber = _confluenceProvider.GetNewPageVersion(pageId);
            if (scenarioRows.Count > 0)
            {
                var confluenceTable = BuildConfluenceTable(scenarioRows, versionNumber, executionTime, env);
                return confluenceTable;
            }

            return null;
        }

        private string BuildScenarioRow(IEnumerable<ExecutionResult> results, string ScenarioTitle, string ticket)
        {
            var scenarioRow = string.Empty;
            foreach (var result in results)
                if (result.ScenarioTitle == ScenarioTitle)
                {
                    if (ticket != string.Empty)
                        scenarioRow =
                            $"<tr><td><p>{result.ScenarioTitle}</p></td><td><p>{result.Status}</p></td><td><p>{ticket}</p></td></tr>";
                    else
                        scenarioRow =
                            $"<tr><td><p>{result.ScenarioTitle}</p></td><td><p>{result.Status}</p></td><td><p>No Linked User Story</p></td></tr>";
                }

            return scenarioRow;
        }

        private CRoot BuildConfluenceTable(
            IEnumerable<string> scenarioRows,
            int versionNumber,
            DateTime executionTime,
            string env)
        {
            var tableParameters =
                "<table data-layout=\"default\" ac:local-id=\"f247c0de-3d7d-4d66-a0dc-2fe5e6e60424\"><colgroup><col style=\"width: 226.67px;\" /><col style=\"width: 226.67px;\" /><col style=\"width: 226.67px;\"";
            var tableHeader =
                "/></colgroup><tbody><tr><th><p><strong>Scenario name</strong></p></th><th><p><strong>Execution Status</strong></p></th><th><p><strong>User Story</strong></p></th></tr>";
            var comment =
                $"<p><strong>Execution time: {executionTime.ToLocalTime()}</strong></p> <p><strong>Environment: {env} </strong></p>";
            var EndTable = "</tbody></table><p/>";
            var sb = new StringBuilder();
            sb.AppendLine(tableParameters);
            sb.AppendLine(tableHeader);
            foreach (var scenario in scenarioRows) sb.AppendLine(scenario);
            sb.AppendLine(EndTable);
            sb.AppendLine(comment);

            var root = new CRoot();
            var body = new CBody();
            var version = new CVersion();
            var storage = new Storage();
            storage.Value = sb.ToString();
            storage.Representation = "storage";
            version.Number = versionNumber;
            root.version = version;
            root.Type = "page";
            root.Title = "Acceptance Testing status for current Sprint";
            body.Storage = storage;
            root.Body = body;
            return root;
        }

        private int GetIssueIdFromTags(List<string> tags)
        {
            var issueId = default(int);
            foreach (var tag in tags)
                if (tag.StartsWith(_issueTag))
                {
                    issueId = GetIssueIdFromTag(tag);
                    return issueId;
                }

            return issueId;
        }

        private string ExtractTicket(List<string> tags)
        {
            var renderedIssue = string.Empty;
            foreach (var tag in tags)
                if (tag.StartsWith(_issueTag))
                {
                    var issueId = GetIssueIdFromTag(tag);
                    var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
                    renderedIssue =
                        $"<ac:structured-macro  ac:name=\"jira\"  ac:schema-version=\"1\" ac:macro-id=\"ce876bed-eeb4-4592-9255-a3a216c1d507\">  <ac:parameter ac:name=\"server\">System JIRA</ac:parameter> <ac:parameter ac:name=\"serverId\">{_baseUrl}</ac:parameter> <ac:parameter ac:name=\"key\">{issueResourceId}</ac:parameter></ac:structured-macro>";
                }
                else
                {
                    renderedIssue = string.Empty;
                }

            return renderedIssue;
        }

        private int GetIssueIdFromTag(string tag)
        {
            return int.Parse(tag.Substring(_issueTag.Length));
        }
    }
}