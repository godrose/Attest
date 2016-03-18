using System;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    interface IInitializationParametersResolutionStrategy<TContainer>        
        where TContainer : IIocContainer, new()
    {
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    abstract class InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        :IInitializationParametersResolutionStrategy<TContainer>         
        where TContainer : IIocContainer, new()
    {
        protected IInitializationParameters<TContainer> CreateInitializationParameters()
        {
            //First a new instance of the IoC container created for each test run
            var container = new TContainer();
            //Then the bootstrapper is instantiated - its signature is constrained to have the IoC container as its only parameter
            Activator.CreateInstance(typeof(TBootstrapper), container);
            return new InitializationParameters<TContainer>(container);
        }

        public abstract IInitializationParameters<TContainer> GetInitializationParameters();
    }
}
