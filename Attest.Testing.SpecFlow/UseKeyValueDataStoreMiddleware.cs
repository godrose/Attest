using Attest.Testing.Context;
using Solid.Bootstrapping;
using Solid.Practices.Middleware;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// This middleware registers dependencies for using <see cref="IKeyValueDataStore"/>.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    public class UseKeyValueDataStoreMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.UseKeyValueDataStore();
            return @object;
        }
    }
}
