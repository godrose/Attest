using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    class InitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer> :
        InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {
        public override IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }
    }
}