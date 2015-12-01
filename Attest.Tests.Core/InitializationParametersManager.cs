using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    public interface IInitializationParametersManager<TContainer>
    {
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    public class InitializationParametersManager<TBootstrapper, TContainer> : 
        IInitializationParametersManager<TContainer>        
        where TContainer : IIocContainer, new()
    {
        private readonly IInitializationParametersResolutionStrategy<TContainer> _initializationParametersResolutionStrategy;

        public InitializationParametersManager(InitializationParametersResolutionStyle initializationParametersResolutionStyle)
        {
            switch (initializationParametersResolutionStyle)
            {
                    case InitializationParametersResolutionStyle.PerRequest:
                    _initializationParametersResolutionStrategy = new InitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer>();
                    break;
                    case InitializationParametersResolutionStyle.PerFolder:
                    _initializationParametersResolutionStrategy = new InitializationParametersPerFolderResolutionStrategy<TBootstrapper, TContainer>();
                    break;
                    case InitializationParametersResolutionStyle.PerFixture:
                    break;
                    case InitializationParametersResolutionStyle.Singleton:
                    break;
                default:
                    break;
            }
        }

        public IInitializationParameters<TContainer> GetInitializationParameters()
        {
            if (_initializationParametersResolutionStrategy == null)
            {
                throw new NotSupportedException("Only per request and per folder styles are supported");
            }
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }

    public class InitializationParametersManager<TContainer> : IInitializationParametersManager<TContainer> 
        where TContainer : IIocContainer, new()
    {
        private readonly IInitializationParametersResolutionStrategy<TContainer> _initializationParametersResolutionStrategy;

        public InitializationParametersManager(TContainer container)
        {
            _initializationParametersResolutionStrategy = new InitializationParametersPredefinedResolutionStrategy<TContainer>(container);
        }

        public IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }
}
