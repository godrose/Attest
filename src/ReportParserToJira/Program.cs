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
            var confluenceParser = new ReportToConfluence();
            confluenceParser.Parse(327681, pathToFeatureDataPath, pathToTestResultsPath,args);
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
