using Attest.Testing.Execution.Models;

namespace Attest.Testing.Execution
{
    public interface ISpecsInfo
    {
        FeatureData FeatureData { get; }
        TestExecution TestExecution { get; }
    }
}
