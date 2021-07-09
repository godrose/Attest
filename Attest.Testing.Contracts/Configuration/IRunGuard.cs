using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents a run guard which is responsible for allowing test/scenario execution.
    /// </summary>
    public interface IRunGuard
    {
        /// <summary>
        /// Returns <see typeref="true"/> if a test/scenario can run depending on the provided configuration,
        /// <see typeref="false"/> otherwise.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        bool CanRun(IConfiguration configuration);
    }
}