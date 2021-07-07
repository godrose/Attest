using System.Collections.Generic;
using Attest.Testing.Modularity;
using Solid.Bootstrapping;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// This middleware registers the main dependencies for
    /// testing lifecycle: <see cref="ISetupService"/> <see cref="ITeardownService"/> and so on
    /// </summary>
    /// <typeparam name="TBootstrapper"></typeparam>
    public class UseLifecycleMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator, IAssemblySourceProvider
    {
        private readonly List<IMiddleware<TBootstrapper>> _middlewares = new List<IMiddleware<TBootstrapper>>
        {
            new RegisterCollectionMiddleware<TBootstrapper, IDynamicApplicationModule>(),
            new RegisterCollectionMiddleware<TBootstrapper, IStaticApplicationModule>(),
            new RegisterCollectionMiddleware<TBootstrapper, ISetupService>(),
            new RegisterCollectionMiddleware<TBootstrapper, ITeardownService>()
        };

        /// <inheritdoc />
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator
                .AddSingleton<IStartDynamicApplicationModuleService, StartDynamicApplicationModuleService>()
                .AddSingleton<IStartStaticApplicationModuleService, StartStaticApplicationModuleService>()
                .AddSingleton<ILifecycleService, StaticLifecycleService>()
                .AddSingleton<IStaticSetupService, StaticSetupService>();
            MiddlewareApplier.ApplyMiddlewares(@object, _middlewares);
            return @object;
        }
    }
}