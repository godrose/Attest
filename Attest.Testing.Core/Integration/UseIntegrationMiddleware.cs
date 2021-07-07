using Attest.Testing.Lifecycle;
using Solid.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Integration
{
    /// <summary>
    /// This middleware registers dependencies used during integration tests.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    public sealed class UseIntegrationMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.UseIntegration();
            return @object;
        }
    }

    /// <summary>
    /// This middleware registers dependencies used during integration tests including start application service.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TStartApplicationService">The type of the start application service.</typeparam>
    public sealed class UseIntegrationMiddleware<TBootstrapper, TStartApplicationService> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator
        where TStartApplicationService : StartApplicationServiceBase
    {
        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator
                .AddSingleton<IStartApplicationService, TStartApplicationService>()
                .UseIntegration();
            return @object;
        }
    }
}
