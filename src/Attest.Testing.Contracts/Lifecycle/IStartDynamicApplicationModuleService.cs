using Attest.Testing.Modularity;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped during the test/scenario execution.
    /// </summary>
    public interface IStartDynamicApplicationModuleService
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="applicationModule">The application.</param>
        void Start(IDynamicApplicationModule applicationModule);
    }
}