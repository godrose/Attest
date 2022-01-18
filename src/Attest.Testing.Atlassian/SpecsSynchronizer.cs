using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attest.Testing.Atlassian.Models;
using Gherkin;
using Gherkin.Ast;
using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian
{
    public class SpecsSynchronizer
    {
        private readonly JiraProvider _jiraProvider;

        public SpecsSynchronizer(JiraProvider jiraProvider)
        {
            _jiraProvider = jiraProvider;
        }

        public void SyncDescriptionFromFilesToJira(int issueId)
        {
            var expectedTag = $"@BDD-{issueId}"; //TODO: use common approach
            var parser = new Parser();
            var rootDir = "..\\..\\..\\Attest.Testing.Atlassian.Specs\\Features";
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

            var raw = _jiraProvider.GetIssueRaw(issueId);
            var currentDescription = raw["fields"]["description"];
            var descObject = new DescriptionContent(currentDescription["content"] as JArray);
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
            var descriptionRoot = raw["fields"]["description"] as JObject;
            descriptionRoot["content"] = content;

            _jiraProvider.UpdateIssueDescription(issueId, descriptionRoot);
        }

        
    }
}
