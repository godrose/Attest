using System;
using Attest.Testing.Core;
using Solid.Bootstrapping;
using Solid.Core;
using Solid.Practices.IoC;
using BootstrapperBase = Attest.Testing.Bootstrapping.BootstrapperBase;

namespace Attest.Testing.SpecFlow
{
    public class StartupBase<TBootstrapper> : IInitializable where TBootstrapper : BootstrapperBase
    {
        private readonly IIocContainer _iocContainer;
        private readonly Func<IIocContainer, TBootstrapper> _bootstrapperCreator;

        public StartupBase(
            IIocContainer iocContainer, 
            Func<IIocContainer, TBootstrapper> bootstrapperCreator)
        {
            _iocContainer = iocContainer;
            _bootstrapperCreator = bootstrapperCreator;
        }

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

        protected void InitializeOverride(TBootstrapper bootstrapper)
        {

        }
    }
}