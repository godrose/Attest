using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    class InitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer> :
        InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>        
        where TContainer : IIocContainer, new()
    {
        public override IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }
    }
}