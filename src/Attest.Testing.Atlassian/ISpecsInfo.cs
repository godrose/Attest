using Attest.Testing.Atlassian.Models;

namespace Attest.Testing.Atlassian
{
    public interface ISpecsInfo
    {
        FeatureData FeatureData { get; }
        TestExecution TestExecution { get; }
    }
}
