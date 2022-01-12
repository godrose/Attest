using System.Linq;
using Attest.Testing.Atlassian;
using Attest.Testing.Execution;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ReportParserToJira
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource
            {
                Path = "./appsettings.json"
            }).Build();
            var confluenceProvider = new ConfluenceProvider(configuration);
            var jiraProvider = new JiraProvider(configuration);
            var pageId = int.Parse(configuration.GetSection("Atlassian").GetSection("Confluence").GetSection("StatusPageId").Value);
            var confluenceContentsFactory = new ConfluenceContentsFactory(
                confluenceProvider,
                jiraProvider,
                configuration, 
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
