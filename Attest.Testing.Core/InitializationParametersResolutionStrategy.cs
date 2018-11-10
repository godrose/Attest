using Solid.Bootstrapping;

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
            var container = RetrieveContainer(bootstrapper);
            return new InitializationParameters<TContainer>(container);
        }

        protected abstract TContainer RetrieveContainer(TBootstrapper bootstrapper);

        public abstract IInitializationParameters<TContainer> GetInitializationParameters();
    }

    abstract class ContainerInitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        : InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer> 
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>, new()                
    {        
        protected override TContainer RetrieveContainer(TBootstrapper bootstrapper)
        {
            return bootstrapper.Container;
        }        
    }

    abstract class ContainerAdapterInitializationParametersResolutionStrategyBase<TBootstrapper>
        : InitializationParametersResolutionStrategyBase<TBootstrapper, IocContainerProxy>
        where TBootstrapper : IInitializable, IHaveRegistrator, IHaveResolver, new()
    {
        protected override IocContainerProxy RetrieveContainer(TBootstrapper bootstrapper)
        {
            return new IocContainerProxy(bootstrapper.Registrator, bootstrapper.Resolver);
        }
    }
}
