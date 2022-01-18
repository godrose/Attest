using System.Linq;
using Attest.Testing.Atlassian;
using Attest.Testing.Reporting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ReportParserToJira
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource
            {
                Path = "./appsettings.json"
            }).Build();
            var atlassianConfigurationProvider = new AtlassianConfigurationProvider(configuration);
            var confluenceProvider = new ConfluenceProvider(atlassianConfigurationProvider);
            var atlassianApiHelper = new AtlassianApiHelper(atlassianConfigurationProvider);
            var jiraProvider = 
                new JiraProvider(atlassianConfigurationProvider, atlassianApiHelper);
            var pageId = atlassianConfigurationProvider.StatusPageId;
            var confluenceContentsFactory = new ConfluenceContentsFactory(
                confluenceProvider,
                jiraProvider,
                atlassianConfigurationProvider,
                atlassianApiHelper,
                new IssueTagParser(new ReportConfigurationProvider(configuration)),
                new FileSystemSpecsInfo());
            var contents = confluenceContentsFactory.BuildContents(
                    pageId,
                    args.FirstOrDefault())
                .ToArray();

            foreach (var content in contents)
            {
                confluenceProvider.UpdatePage(pageId, content);
            }
        }
    }
}