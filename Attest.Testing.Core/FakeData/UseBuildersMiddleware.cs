using Solid.Bootstrapping;
using Solid.Practices.Middleware;

namespace Attest.Testing.FakeData
{
    /// <summary>
    /// This middleware registers dependencies used during integration tests.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    public sealed class UseBuildersMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.UseBuilders();
            return @object;
        }
    }
}
