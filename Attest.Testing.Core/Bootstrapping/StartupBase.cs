using System;
using Attest.Testing.Lifecycle;
using Solid.Bootstrapping;
using Solid.Core;
using Solid.Practices.IoC;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Bootstrapping
{
    /// <summary>
    /// Base class for bootstrapper initialization.
    /// Used to register common dependencies and start common flows.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    public class StartupBase<TBootstrapper> : IInitializable where TBootstrapper : BootstrapperBase
    {
        private readonly IIocContainer _iocContainer;
        private readonly Func<IIocContainer, TBootstrapper> _bootstrapperCreator;

        /// <summary>
        /// Creates an instance of <see cref="StartupBase{TBootstrapper}"/>
        /// </summary>
        /// <param name="iocContainer">The IoC container.</param>
        /// <param name="bootstrapperCreator">The bootstrapper creation function.</param>
        public StartupBase(
            IIocContainer iocContainer, 
            Func<IIocContainer, TBootstrapper> bootstrapperCreator)
        {
            _iocContainer = iocContainer;
            _bootstrapperCreator = bootstrapperCreator;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            var bootstrapper = _bootstrapperCreator(_iocContainer);
            bootstrapper
                .Use(new RegisterCustomCompositionModulesMiddleware<BootstrapperBase, IDependencyRegistrator>())
                .Use(new UseLifecycleMiddleware<BootstrapperBase>())
                .Use(new RegisterResolverMiddleware<BootstrapperBase>(_iocContainer));

            InitializeOverride(bootstrapper);
            bootstrapper.Initialize();
        }

        /// <summary>
        /// Override to inject custom behavior during initialization.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper.</param>
        protected virtual void InitializeOverride(TBootstrapper bootstrapper)
        {

        }
    }
}