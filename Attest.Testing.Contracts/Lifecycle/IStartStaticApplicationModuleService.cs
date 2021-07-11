using Attest.Testing.Modularity;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped once during the whole test/scenario suite execution.
    /// </summary>
    public interface IStartStaticApplicationModuleService
    {
        /// <summary>Starts the application.</summary>
        /// <param name="applicationModule">The application.</param>
        int Start(IStaticApplicationModule applicationModule);
    }
}
