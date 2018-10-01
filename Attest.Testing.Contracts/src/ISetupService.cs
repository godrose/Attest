namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This service encapsulates functionality which is called when the test/scenario starts.
    /// </summary>
    public interface ISetupService
    {
        /// <summary>
        /// Setups this instance.
        /// </summary>
        void Setup();
    }
}