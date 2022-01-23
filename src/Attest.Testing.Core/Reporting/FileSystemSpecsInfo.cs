using System.IO;
using Attest.Testing.Common;
using Attest.Testing.Reporting.Models;
using Newtonsoft.Json;

namespace Attest.Testing.Reporting
{
    /// <summary>
    /// Represents file system-based specs execution information.
    /// </summary>
    public class FileSystemSpecsInfo : ISpecsInfo
    {
        private readonly string _pathToFeatureData = $"{Utils.GetPathToSolutionRoot()}FeatureData.json";
        private readonly string _pathToTestExecution = $"{Utils.GetPathToSolutionRoot()}TestExecution.json";
        
        private TestExecution _testExecution;
        /// <summary>
        /// Gets the test execution information.
        /// </summary>
        public TestExecution TestExecution => _testExecution ?? (_testExecution = BuildFromFile<TestExecution>(_pathToTestExecution));

        private FeatureData _featureData;
        /// <summary>
        /// Gets the feature data information.
        /// </summary>
        public FeatureData FeatureData => _featureData ?? (_featureData = BuildFromFile<FeatureData>(_pathToFeatureData));

        private static T BuildFromFile<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
