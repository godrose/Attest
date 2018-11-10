namespace Attest.Testing.Core
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
#if NET45
        /// <summary>
        /// New copy of initialization parameters is created for each folder
        /// </summary>
        PerFolder,
#endif

        /// <summary>
        /// Initialization parameters are created once
        /// </summary>
        Singleton
    }
}
