using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attest.Testing.Atlassian.Models;
using Attest.Testing.Reporting;
using Gherkin;
using Gherkin.Ast;
using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian
{
    public class SpecsSynchronizer
    {
        private readonly JiraProvider _jiraProvider;
        private readonly DescriptionContentWithSpecsFactory _descriptionContentFactory;
        private readonly IssueTagParser _issueTagParser;
        private readonly SpecsConfigurationProvider _specsConfigurationProvider;

        public SpecsSynchronizer(
            JiraProvider jiraProvider, 
            DescriptionContentWithSpecsFactory descriptionContentFactory, 
            IssueTagParser issueTagParser,
            SpecsConfigurationProvider specsConfigurationProvider)
        {
            _jiraProvider = jiraProvider;
            _descriptionContentFactory = descriptionContentFactory;
            _issueTagParser = issueTagParser;
            _specsConfigurationProvider = specsConfigurationProvider;
        }

        public void SyncDescriptionFromFilesToJira(int issueId)
        {
            var expectedTag = _issueTagParser.BuildTagFromIssueId(issueId);
            var parser = new Parser();
            var rootDir = _specsConfigurationProvider.RootDir;
            var featureFiles = Directory.GetFiles(rootDir, "*.feature", SearchOption.AllDirectories).ToArray();
            var lines = new List<string>();

            foreach (var featureFile in featureFiles)
            {
                var gherkinDocument = parser.Parse(featureFile);
                var featureTags = gherkinDocument.Feature.Tags;
                if (featureTags.Any(tag => tag.Name == expectedTag) == false)
                {
                    continue;
                }
                lines.Add($"Feature: {gherkinDocument.Feature.Name}");
                lines.Add(Environment.NewLine);
                var descriptionParts = gherkinDocument.Feature.Description.Split(new
                    [] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);
                lines.AddRange(descriptionParts);
                lines.Add(Environment.NewLine);
                var scenarios = gherkinDocument.Feature.Children.OfType<Scenario>();
                foreach (var scenario in scenarios)
                {
                    lines.Add($"Scenario: {scenario.Name}");
                    lines.Add(Environment.NewLine);
                    foreach (var step in scenario.Steps)
                    {
                        lines.Add($"{step.Keyword.Trim()} {step.Text}");
                    }
                    lines.Add(Environment.NewLine);
                }
            }

            if (lines.Last() == Environment.NewLine)
            {
                lines.RemoveAt(lines.Count-1);
            }

            var issue = _jiraProvider.GetIssue(issueId);
            var descObject = _descriptionContentFactory.Create(issue);
            var specs = new List<JToken>();
            foreach (var line in lines)
            {
                if (line == Environment.NewLine)
                {
                    specs.Add(new JObject(
                        
                        new JProperty("type", "paragraph"), 
                        new JProperty("content", new JArray())));
                }
                else
                {
                    specs.Add(Paragraph.TextToJiraParagraph(line));
                }
            }
            descObject.UpdateSpecs(specs);
            var content = new JArray(descObject.GetAll());
            issue.Description.Content = content;

            _jiraProvider.UpdateIssueDescription(issueId, issue.Description);
        }

        
    }
}
