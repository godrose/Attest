namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents a service which possesses both setup and teardown capabilities.
    /// </summary>
    public interface ILifecycleService : ISetupService, ITeardownService
    {
    }
}
