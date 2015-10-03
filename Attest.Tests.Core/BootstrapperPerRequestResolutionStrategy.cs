using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    class BootstrapperPerRequestResolutionStrategy<TBootstrapper, TContainer> :
        BootstrapperResolutionStrategyBase<TBootstrapper, TContainer>
        where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {
        public override TBootstrapper GetBootstrapper()
        {
            return CreateBootstrapper();
        }
    }
}