using System;
using System.Collections.Generic;
using System.Text;
using Attest.Testing.Atlassian.Models;

namespace Attest.Testing.Atlassian
{
    public class ConfluenceContentsFactory
    {
        public const string JiraUserStoryPrefix = "BDD-";
        public const string UserStoryTag = "@" + JiraUserStoryPrefix;
        private readonly ISpecsInfo _specsInfo;

        public ConfluenceContentsFactory(ISpecsInfo specsInfo)
        {
            _specsInfo = specsInfo;
        }

        public IEnumerable<object> BuildContents(int pageId, string env)
        {
            foreach (var node in _specsInfo.FeatureData.Nodes)
            foreach (var folder in node.Folders)
                yield return BuildContent(pageId, _specsInfo.TestExecution.ExecutionResults, folder, _specsInfo.TestExecution.ExecutionTime, env);
        }

        private object BuildContent(
            int pageId,
            IEnumerable<ExecutionResult> executionResults,
            Folder folder,
            DateTime executionTime,
            string env)
        {
            var workflowHelper = new WorkflowHelper();
            var scenarioRows = new List<string>();

            foreach (var fold in folder.Folders)
            foreach (var feature in fold.Features)
            foreach (var result in executionResults)
                if (feature.Title == result.FeatureTitle)
                    foreach (var scenario in feature.ScenarioDefinitions)
                        if (scenario.Title == result.ScenarioTitle)
                        {
                            var ticket = ExtractTicket(scenario.Tags);
                            var issue = GetTicket(scenario.Tags);
                            if (issue != default)
                                if (workflowHelper.IsCurrentSprint(issue))
                                {
                                    var Scenario = AddScenarioRows(executionResults, scenario.Title, ticket);
                                    scenarioRows.Add(Scenario);
                                }
                        }

            var versionNumber = workflowHelper.SendContentGetRequest(pageId);
            if (scenarioRows.Count > 0)
            {
                var confluenceTable = BuildConfluenceTable(scenarioRows, versionNumber, executionTime, env);
                return confluenceTable;
            }

            return null;
        }

        private string AddScenarioRows(IEnumerable<ExecutionResult> results, string ScenarioTitle, string ticket)
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
            foreach (var scenario in scenarioRows)
            {
                sb.AppendLine(scenario);
            }
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

        private int GetTicket(List<string> tags)
        {
            var ticket = default(int);
            foreach (var tag in tags) 
                if (tag.StartsWith(UserStoryTag))
                {
                    ticket = GetTicketFromTag(tag);
                    return ticket;
                }

            return ticket;
        }

        private string ExtractTicket(List<string> tags)
        {
            var renderedIssue = string.Empty;
            foreach (var tag in tags)
                if (tag.StartsWith(UserStoryTag))
                {
                    var ticket = GetTicketFromTag(tag);
                    renderedIssue =
                        $"<ac:structured-macro  ac:name=\"jira\"  ac:schema-version=\"1\" ac:macro-id=\"ce876bed-eeb4-4592-9255-a3a216c1d507\">  <ac:parameter ac:name=\"server\">System JIRA</ac:parameter> <ac:parameter ac:name=\"serverId\">https://godrose.atlassian.net/</ac:parameter> <ac:parameter ac:name=\"key\">{JiraUserStoryPrefix}{ticket}</ac:parameter></ac:structured-macro>";
                }
                else
                {
                    renderedIssue = string.Empty;
                }

            return renderedIssue;
        }

        private int GetTicketFromTag(string tag)
        {
            return int.Parse(tag.Substring(UserStoryTag.Length));
        }
    }
}