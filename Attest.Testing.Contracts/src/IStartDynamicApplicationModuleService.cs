namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped during the test.
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