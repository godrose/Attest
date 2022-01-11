using System.Linq;
using Attest.Testing.Atlassian;
using Attest.Testing.Common;

namespace ReportParserToJira
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFeatureDataPath = $"{Utils.GetPathToSolutionRoot()}FeatureData.json";
            string pathToTestResultsPath = $"{Utils.GetPathToSolutionRoot()}TestExecution.json";
            var workflowHelper = new WorkflowHelper();
            int pageId = 327681;
            var confluenceContentsFactory = new ConfluenceContentsFactory(new FileSystemSpecsInfo());
            var contents = confluenceContentsFactory.BuildContents(
                pageId,
                args.FirstOrDefault())
                .ToArray();

            foreach (var content in contents)
            {
                workflowHelper.SendPostRequest(pageId, content);
            }
        }
    }
}
