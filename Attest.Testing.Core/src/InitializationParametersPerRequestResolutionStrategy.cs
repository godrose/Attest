using Solid.Bootstrapping;
using Solid.Practices.IoC;

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

    class ContainerAdapterInitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainerAdapter> :
        ContainerAdapterInitializationParametersResolutionStrategyBase<TBootstrapper, TContainerAdapter>
        where TBootstrapper : IInitializable, IHaveContainerAdapter<TContainerAdapter>, new() 
        where TContainerAdapter : IIocContainer
    {
        public override IInitializationParameters<TContainerAdapter> GetInitializationParameters()
        {
            return CreateInitializationParameters();
        }
    }
}