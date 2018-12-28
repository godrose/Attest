using System;
using Solid.Bootstrapping;
using Solid.Core;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" />
    /// </summary>
    /// <typeparam name="TContainer">The type of the ioc container.</typeparam>
    public interface IInitializationParametersManager<TContainer>
    {
        /// <summary>
        /// Gets the initialization parameters.
        /// </summary>
        /// <returns></returns>
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    /// <summary>
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" /> for given bootstrapper and ioc container.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainer">The type of the ioc container.</typeparam>
    /// <seealso cref="Core.IInitializationParametersManager{TContainer}" />
    class ContainerInitializationParametersManager<TBootstrapper, TContainer> : 
        IInitializationParametersManager<TContainer>                
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>,  new()
    {
        private readonly IInitializationParametersResolutionStrategy<TContainer> _initializationParametersResolutionStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerInitializationParametersManager{TBootstrapper,TContainer}"/> class.
        /// </summary>
        /// <param name="initializationParametersResolutionStyle">The initialization parameters resolution style.</param>
        public ContainerInitializationParametersManager(
            InitializationParametersResolutionStyle initializationParametersResolutionStyle)
        {
            switch (initializationParametersResolutionStyle)
            {
                    case InitializationParametersResolutionStyle.PerRequest:
                    _initializationParametersResolutionStrategy = new 
                        ContainerInitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer>();
                    break;
//#if NET45
//                    case InitializationParametersResolutionStyle.PerFolder:
//                    _initializationParametersResolutionStrategy = new InitializationParametersPerFolderResolutionStrategy<TBootstrapper, TContainer>();
//                    break;
//#endif
                    case InitializationParametersResolutionStyle.PerFixture:
                    break;
                    case InitializationParametersResolutionStyle.Singleton:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the initialization parameters.
        /// </summary>
        /// <returns></returns>
        public IInitializationParameters<TContainer> GetInitializationParameters()
        {
            if (_initializationParametersResolutionStrategy == null)
            {
                throw new NotSupportedException("Only per request and per folder styles are supported");
            }
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }

    /// <summary>
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" /> for given bootstrapper and ioc container adapter.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <seealso cref="Core.IInitializationParametersManager{TContainer}" />
    class ContainerAdapterInitializationParametersManager<TBootstrapper> :
        IInitializationParametersManager<IocContainerProxy>
        where TBootstrapper : IInitializable, IHaveRegistrator, IHaveResolver, new()
    {
        private readonly IInitializationParametersResolutionStrategy<IocContainerProxy> _initializationParametersResolutionStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attest.Testing.Core.ContainerInitializationParametersManager{TBootstrapper,TContainer}"/> class.
        /// </summary>
        /// <param name="initializationParametersResolutionStyle">The initialization parameters resolution style.</param>
        public ContainerAdapterInitializationParametersManager(
            InitializationParametersResolutionStyle initializationParametersResolutionStyle)
        {
            switch (initializationParametersResolutionStyle)
            {
                case InitializationParametersResolutionStyle.PerRequest:
                    _initializationParametersResolutionStrategy =
                        new ContainerAdapterInitializationParametersPerRequestResolutionStrategy<TBootstrapper>();
                    break;
//#if NET45
//                    case InitializationParametersResolutionStyle.PerFolder:
//                    _initializationParametersResolutionStrategy = new InitializationParametersPerFolderResolutionStrategy<TBootstrapper, TContainer>();
//                    break;
//#endif
                case InitializationParametersResolutionStyle.PerFixture:
                    break;
                case InitializationParametersResolutionStyle.Singleton:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the initialization parameters.
        /// </summary>
        /// <returns></returns>
        public IInitializationParameters<IocContainerProxy> GetInitializationParameters()
        {
            if (_initializationParametersResolutionStrategy == null)
            {
                throw new NotSupportedException("Only per request and per folder styles are supported");
            }
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }
}
