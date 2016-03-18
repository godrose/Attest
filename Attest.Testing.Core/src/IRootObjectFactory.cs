namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents a root object factory which is used to create root object instances in specflow-based scenario runs
    /// </summary>
    public interface IRootObjectFactory
    {
        /// <summary>
        /// Creates root object
        /// </summary>
        /// <returns>Root object</returns>
        object CreateRootObject();
    }
}