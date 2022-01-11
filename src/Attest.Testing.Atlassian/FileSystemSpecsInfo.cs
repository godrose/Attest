using System.IO;
using Attest.Testing.Atlassian.Models;
using Attest.Testing.Common;
using Newtonsoft.Json;

namespace Attest.Testing.Atlassian
{
    public class FileSystemSpecsInfo : ISpecsInfo
    {
        private readonly string _pathToFeatureData = $"{Utils.GetPathToSolutionRoot()}FeatureData.json";
        private readonly string _pathToTestExecution = $"{Utils.GetPathToSolutionRoot()}TestExecution.json";
        
        private TestExecution _testExecution;
        public TestExecution TestExecution => _testExecution ?? (_testExecution = BuildFromFile<TestExecution>(_pathToTestExecution));

        private FeatureData _featureData;
        public FeatureData FeatureData => _featureData ?? (_featureData = BuildFromFile<FeatureData>(_pathToFeatureData));

        private T BuildFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
