using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    interface IBootstrapperResolutionStrategy<TBootstrapper, TContainer>
        where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {
        TBootstrapper GetBootstrapper();
    }

    abstract class BootstrapperResolutionStrategyBase<TBootstrapper, TContainer>
        :IBootstrapperResolutionStrategy<TBootstrapper, TContainer> where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {
        protected TBootstrapper CreateBootstrapper()
        {
            //First a new instance of the IoC container created for each test run
            var container = new TContainer();
            //Then the bootstrapper is instantiated - its signature is constrained to have the IoC container as its only parameter
            return (TBootstrapper)Activator.CreateInstance(typeof(TBootstrapper), container);
        }

        public abstract TBootstrapper GetBootstrapper();
    }
}
