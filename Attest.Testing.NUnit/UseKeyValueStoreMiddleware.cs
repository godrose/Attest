using Attest.Testing.Core;
using Solid.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Attest.Testing.NUnit
{
    /// <summary>
    /// This middleware registers dependencies for using <see cref="IKeyValueDataStore"/>.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    public class UseKeyValueStoreMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.AddSingleton<IKeyValueDataStore, TestContextKeyValueDataStoreAdapter>();
            return @object;
        }
    }
}
