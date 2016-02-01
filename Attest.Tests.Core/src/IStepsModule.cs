using System.Collections.Generic;
using Solid.Practices.Modularity;

namespace Attest.Tests.Core
{
    /// <summary>
    /// This interface represents a composable module
    /// that contains steps providers
    /// </summary>
    public interface IStepsModule : ICompositionModule
    {
        /// <summary>
        /// returns collection of steps providers associated with the steps module
        /// </summary>
        /// <returns></returns>
        IEnumerable<IStepsProvider> GetStepsProviders();
    }
}