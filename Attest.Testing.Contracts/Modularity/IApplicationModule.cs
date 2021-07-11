using Solid.Core;

namespace Attest.Testing.Modularity
{
    /// <summary>
    /// This interface represents an application module that
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