using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    public interface IInitializationParametersManager<TBootstrapper, TContainer>
    {
        IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters();
    }

    public class InitializationParametersManager<TBootstrapper, TContainer> : IInitializationParametersManager<TBootstrapper, TContainer> where TBootstrapper : new() where TContainer : IIocContainer, new()
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
                default:
                    throw new NotSupportedException("Only per request and per folder styles are supported");
            }
        }

        public IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters()
        {
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }
}
