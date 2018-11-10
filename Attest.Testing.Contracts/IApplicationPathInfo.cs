namespace  Attest.Testing.Contracts
{
    /// <summary>
    /// Represents the application path information.
    /// </summary>
    public interface IApplicationPathInfo
    {
        /// <summary>
        /// The app's entry point.
        /// </summary>
        string Executable { get; }

        /// <summary>
        /// The path of the app's folder relatively to the test folder.
        /// </summary>
        string RelativePath { get; }
    }
}
