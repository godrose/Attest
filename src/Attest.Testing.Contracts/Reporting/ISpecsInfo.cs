using Attest.Testing.Reporting.Models;

namespace Attest.Testing.Reporting
{
    /// <summary>
    /// Represents specs execution information.
    /// </summary>
    public interface ISpecsInfo
    {
        /// <summary>
        /// Gets the feature data information.
        /// </summary>
        FeatureData FeatureData { get; }
        /// <summary>
        /// Gets the test execution information.
        /// </summary>
        TestExecution TestExecution { get; }
    }
}
