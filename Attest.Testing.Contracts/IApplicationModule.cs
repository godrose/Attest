using Solid.Core;

namespace Attest.Testing.Contracts
{
    /// <summary>
    /// This interface represents a local application that
    /// can be uniquely identified and executed
    /// </summary>
    public interface IApplicationModule : IIdentifiable
    {        
        /// <summary>
        /// Application's relative path.
        /// </summary>
        string RelativePath { get; }       
    }
}