using System;

namespace Attest.Testing.Core
{
    class InitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer> :
        InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>        
        where TContainer : new()
    {
        public InitializationParametersPerRequestResolutionStrategy(Action<TBootstrapper> bootstrapperInit) 
            : base(bootstrapperInit)
        {
        }

        public override IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }        
    }
}