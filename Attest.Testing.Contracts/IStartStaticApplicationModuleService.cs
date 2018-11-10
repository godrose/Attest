namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped once during the test session.
    /// </summary>
    public interface IStartStaticApplicationModuleService
    {
        /// <summary>Starts the application.</summary>
        /// <param name="applicationModule">The application.</param>
        int Start(IStaticApplicationModule applicationModule);
    }
}
