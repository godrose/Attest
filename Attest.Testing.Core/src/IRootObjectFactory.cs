namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents a root object factory which is used to create root object instances.
    /// </summary>
    public interface IRootObjectFactory
    {
        /// <summary>
        /// Creates root object.
        /// </summary>
        /// <returns>Root object.</returns>
        object CreateRootObject();
    }
}