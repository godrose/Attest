using Solid.Bootstrapping;

namespace Attest.Testing.Core
{
    class ContainerInitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer> :
        ContainerInitializationParametersResolutionStrategyBase<TBootstrapper, TContainer> 
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>, new()
    {
        public override IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }        
    }

    class ContainerAdapterInitializationParametersPerRequestResolutionStrategy<TBootstrapper> :
        ContainerAdapterInitializationParametersResolutionStrategyBase<TBootstrapper>
        where TBootstrapper : IInitializable, IHaveRegistrator, IHaveResolver, new()
    {
        public override IInitializationParameters<IocContainerProxy> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }
    }
}