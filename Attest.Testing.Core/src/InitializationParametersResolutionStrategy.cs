using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    interface IInitializationParametersResolutionStrategy<TContainer>       
    {
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    abstract class InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        :IInitializationParametersResolutionStrategy<TContainer>
        where TBootstrapper : IInitializable, new()
    {
        protected IInitializationParameters<TContainer> CreateInitializationParameters()
        {
            var bootstrapper = new TBootstrapper();
            bootstrapper.Initialize();
            TContainer container = RetrieveContainer(bootstrapper);
            return new InitializationParameters<TContainer>(container);
        }

        protected abstract TContainer RetrieveContainer(TBootstrapper bootstrapper);

        public abstract IInitializationParameters<TContainer> GetInitializationParameters();
    }

    abstract class ContainerInitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        : InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer> 
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>,  new()                
    {        
        protected override TContainer RetrieveContainer(TBootstrapper bootstrapper)
        {
            return bootstrapper.Container;
        }        
    }

    abstract class ContainerAdapterInitializationParametersResolutionStrategyBase<TBootstrapper, TContainerAdapter>
        : InitializationParametersResolutionStrategyBase<TBootstrapper, TContainerAdapter>
        where TBootstrapper : IInitializable, IHaveContainerAdapter<TContainerAdapter>, new() 
        where TContainerAdapter : IIocContainer
    {
        protected override TContainerAdapter RetrieveContainer(TBootstrapper bootstrapper)
        {
            return bootstrapper.ContainerAdapter;
        }
    }
}
