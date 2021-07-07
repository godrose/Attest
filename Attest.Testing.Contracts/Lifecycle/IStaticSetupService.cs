using System.Collections.Generic;
using Attest.Testing.Modularity;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents static setup functionality.
    /// </summary>
    public interface IStaticSetupService
    {
        /// <summary>
        /// Invokes one-time static setup functionality and initializes
        /// the static application modules
        /// </summary>
        /// <returns></returns>
        Dictionary<int, IStaticApplicationModule> OneTimeSetup();
    }
}
