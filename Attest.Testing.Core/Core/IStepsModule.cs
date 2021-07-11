using System.Collections.Generic;
using Solid.Practices.Modularity;

namespace Attest.Testing.Core
{
    /// <summary>
    /// This interface represents a composition module
    /// that contains steps providers
    /// </summary>
    public interface IStepsModule : ICompositionModule
    {
        /// <summary>
        /// Returns collection of steps providers associated with the steps module
        /// </summary>
        /// <returns></returns>
        IEnumerable<IStepsProvider> GetStepsProviders();
    }
}