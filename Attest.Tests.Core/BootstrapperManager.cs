using System;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    public interface IBootstrapperManager<TBootstrapper, TContainer>
    {
        Tuple<TBootstrapper, TContainer> GetInitializationParameters();
    }

    public class BootstrapperManager<TBootstrapper, TContainer> : IBootstrapperManager<TBootstrapper, TContainer> where TBootstrapper : new() where TContainer : IIocContainer, new()
    {
        private IBootstrapperResolutionStrategy<TBootstrapper, TContainer> _bootstrapperResolutionStrategy;

        public BootstrapperManager(BootstrapperResolutionStyle bootstrapperResolutionStyle)
        {
            switch (bootstrapperResolutionStyle)
            {
                    case BootstrapperResolutionStyle.PerRequest:
                    _bootstrapperResolutionStrategy = new BootstrapperPerRequestResolutionStrategy<TBootstrapper, TContainer>();
                    break;
                    case BootstrapperResolutionStyle.PerFolder:
                    _bootstrapperResolutionStrategy = new BootstrapperPerFolderResolutionStrategy<TBootstrapper, TContainer>();
                    break;
                default:
                    throw new NotSupportedException("Only per request and per folder styles are supported");
            }
        }

        public Tuple<TBootstrapper, TContainer> GetInitializationParameters()
        {
            throw new NotImplementedException();
        }
    }
}
