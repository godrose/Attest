using System;

namespace Attest.Testing.Core
{
    interface IInitializationParametersResolutionStrategy<TContainer>        
        where TContainer : new()
    {
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    abstract class InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        :IInitializationParametersResolutionStrategy<TContainer>         
        where TContainer : new()
    {
        private readonly Action<TBootstrapper> _bootstrapperInit;

        protected InitializationParametersResolutionStrategyBase(Action<TBootstrapper> bootstrapperInit)
        {
            _bootstrapperInit = bootstrapperInit;
        }

        protected IInitializationParameters<TContainer> CreateInitializationParameters()
        {
            //First a new instance of the IoC container created for each test run
            var container = new TContainer();
            //Then the bootstrapper is instantiated - its signature is constrained to have the IoC container as its only parameter
            var bootstrapper = (TBootstrapper)Activator.CreateInstance(typeof(TBootstrapper), container);
            _bootstrapperInit(bootstrapper);
            return new InitializationParameters<TContainer>(container);
        }

        public abstract IInitializationParameters<TContainer> GetInitializationParameters();
    }
}
