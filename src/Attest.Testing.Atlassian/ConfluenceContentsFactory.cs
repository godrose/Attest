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
        private readonly ConfluenceProvider _confluenceProvider;
        private readonly JiraProvider _jiraProvider;
        private readonly AtlassianApiHelper _atlassianApiHelper;
        private readonly IssueTagParser _issueTagParser;
        private readonly ISpecsInfo _specsInfo;
        private readonly string _baseUrl;

        public ConfluenceContentsFactory(
            ConfluenceProvider confluenceProvider,
            JiraProvider jiraProvider,
            AtlassianConfigurationProvider atlassianConfigurationProvider,
            AtlassianApiHelper atlassianApiHelper,
            IssueTagParser issueTagParser,
            ISpecsInfo specsInfo)
        {
            _confluenceProvider = confluenceProvider;
            _jiraProvider = jiraProvider;
            _atlassianApiHelper = atlassianApiHelper;
            _issueTagParser = issueTagParser;
            _specsInfo = specsInfo;
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
                            var issueId = _issueTagParser.GetIssueIdFromTags(scenario.Tags);
                            if (issueId != IssueTagParser.DefaultIssueId)
                                if (_jiraProvider.IsIssueIncludedInTheCurrentSprint(issueId))
                                {
                                    var issueLink = BuildIssueLink(issueId); 
                                    var scenarioRow = BuildScenarioRow(executionResults, scenario.Title, issueLink);
                                    scenarioRows.Add(scenarioRow);
                                }
                        }

            if (scenarioRows.Count > 0)
            {
                var versionNumber = _confluenceProvider.GetNewPageVersion(pageId);
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

        private string BuildIssueLink(int issueId)
        {
            var renderedIssue = string.Empty;
            if (issueId != IssueTagParser.DefaultIssueId)
            {
                var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
                renderedIssue =
                    $"<ac:structured-macro  ac:name=\"jira\"  ac:schema-version=\"1\" ac:macro-id=\"ce876bed-eeb4-4592-9255-a3a216c1d507\">  <ac:parameter ac:name=\"server\">System JIRA</ac:parameter> <ac:parameter ac:name=\"serverId\">{_baseUrl}</ac:parameter> <ac:parameter ac:name=\"key\">{issueResourceId}</ac:parameter></ac:structured-macro>";
            }

            return renderedIssue;
        }

    }
}