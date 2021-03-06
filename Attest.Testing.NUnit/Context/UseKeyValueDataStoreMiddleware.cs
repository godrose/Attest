using Solid.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.NUnit
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
            @object.Registrator.AddSingleton<IKeyValueDataStore, TestContextKeyValueDataStoreAdapter>();
            return @object;
        }
    }
}
