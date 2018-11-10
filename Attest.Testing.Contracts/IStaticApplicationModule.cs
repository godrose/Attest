namespace Attest.Testing.Contracts
{
    /// <summary>
    /// Represents an application module that is started and stopped once
    /// during the test session.
    /// </summary>
    public interface IStaticApplicationModule : IApplicationModule
    {        
        /// <summary>Starts the application.</summary>
        int Start();

        /// <summary>Stops the application.</summary>
        void Stop(int handle);
    }
}
