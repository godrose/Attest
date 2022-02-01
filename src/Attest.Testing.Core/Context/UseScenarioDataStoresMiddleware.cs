using Attest.Testing.Bootstrapping;
using Solid.Practices.Middleware;

namespace Attest.Testing.Context
{
    /// <summary>
    /// This middleware allows using scenario data stores.
    /// </summary>
    /// <typeparam name="TBootstrapper"></typeparam>
    public class UseScenarioDataStoresMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : BootstrapperBase
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterScenarioDataStoresAsContracts(@object.Assemblies);
            return @object;
        }
    }
}
