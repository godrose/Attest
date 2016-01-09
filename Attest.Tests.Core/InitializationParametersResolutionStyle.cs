namespace Attest.Tests.Core
{
    /// <summary>
    /// Contains values for initialization parameters resolution style
    /// </summary>
    public enum InitializationParametersResolutionStyle
    {
        /// <summary>
        /// New copy of initialization parameters is created for each request
        /// </summary>
        PerRequest,

        /// <summary>
        /// New copy of initialization parameters is created for each test suite
        /// </summary>
        PerFixture,

        /// <summary>
        /// New copy of initialization parameters is created for each folder
        /// </summary>
        PerFolder,

        /// <summary>
        /// Initialization parameters are created once
        /// </summary>
        Singleton
    }
}
