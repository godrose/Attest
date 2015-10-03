using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    interface IInitializationParametersResolutionStrategy<TBootstrapper, TContainer>        
        where TContainer : IIocContainer, new()
    {
        IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters();
    }

    abstract class InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        :IInitializationParametersResolutionStrategy<TBootstrapper, TContainer>         
        where TContainer : IIocContainer, new()
    {
        protected IInitializationParameters<TBootstrapper, TContainer> CreateInitializationParameters()
        {
            //First a new instance of the IoC container created for each test run
            var container = new TContainer();
            //Then the bootstrapper is instantiated - its signature is constrained to have the IoC container as its only parameter
            Activator.CreateInstance(typeof(TBootstrapper), container);
            return new InitializationParameters<TBootstrapper, TContainer>(container);
        }

        public abstract IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters();
    }
}
