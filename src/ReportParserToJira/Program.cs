using System;
using System.IO;
using System.Linq;
using Attest.Testing.Atlassian;

namespace ReportParserToJira
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFeatureDataPath = $"{GetPathToSolutionRoot()}FeatureData.json";
            string pathToTestResultsPath = $"{GetPathToSolutionRoot()}TestExecution.json";
            var workflowHelper = new WorkflowHelper();
            int pageId = 327681;
            var confluenceParser = new ReportToConfluence();
            var contents = confluenceParser.Parse(pageId, pathToFeatureDataPath, pathToTestResultsPath,args).ToArray();
            foreach (var content in contents)
            {
                workflowHelper.SendPostRequest(pageId, content);
            }
        }

        private static string GetPathToSolutionRoot()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            while (!Directory.GetFiles(dirPath, "*.sln", SearchOption.TopDirectoryOnly).Any())
            {
                dirPath = Path.GetFullPath(dirPath + "../");
            }

            const string expectedEnding = @"/";
            if (!dirPath.EndsWith(expectedEnding))
            {
                dirPath += expectedEnding;
            }

            return dirPath;
        }
    }
}
