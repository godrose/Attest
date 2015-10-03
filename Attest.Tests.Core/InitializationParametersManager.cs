using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    public interface IInitializationParametersManager<TBootstrapper, TContainer>
    {
        IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters();
    }

    public class InitializationParametersManager<TBootstrapper, TContainer> : 
        IInitializationParametersManager<TBootstrapper, TContainer>        
        where TContainer : IIocContainer, new()
    {
        private readonly IInitializationParametersResolutionStrategy<TBootstrapper, TContainer> _initializationParametersResolutionStrategy;

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

        public IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters()
        {
            if (_initializationParametersResolutionStrategy == null)
            {
                throw new NotSupportedException("Only per request and per folder styles are supported");
            }
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }
}
