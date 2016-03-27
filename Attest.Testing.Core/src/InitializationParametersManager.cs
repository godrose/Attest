using System;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" />
    /// </summary>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    public interface IInitializationParametersManager<TContainer>
    {
        /// <summary>
        /// Gets the initialization parameters.
        /// </summary>
        /// <returns></returns>
        IInitializationParameters<TContainer> GetInitializationParameters();
    }

    /// <summary>
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" /> for given bootstrapper and IoC container
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    /// <seealso cref="Core.IInitializationParametersManager{TContainer}" />
    public class InitializationParametersManager<TBootstrapper, TContainer> : 
        IInitializationParametersManager<TContainer>        
        where TContainer : new()
    {
        private readonly IInitializationParametersResolutionStrategy<TContainer> _initializationParametersResolutionStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationParametersManager{TBootstrapper, TContainer}"/> class.
        /// </summary>
        /// <param name="initializationParametersResolutionStyle">The initialization parameters resolution style.</param>
        /// <param name="bootstrapperInit"></param>
        public InitializationParametersManager(
            InitializationParametersResolutionStyle initializationParametersResolutionStyle,
            Action<TBootstrapper> bootstrapperInit)
        {
            switch (initializationParametersResolutionStyle)
            {
                    case InitializationParametersResolutionStyle.PerRequest:
                    _initializationParametersResolutionStrategy = new 
                        InitializationParametersPerRequestResolutionStrategy<TBootstrapper, TContainer>(bootstrapperInit);
                    break;
#if NET45
                    case InitializationParametersResolutionStyle.PerFolder:
                    _initializationParametersResolutionStrategy = new InitializationParametersPerFolderResolutionStrategy<TBootstrapper, TContainer>();
                    break;
#endif
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
    /// Represents means of retrieving <see cref="IInitializationParameters{TContainer}" /> for given IoC container
    /// </summary>    
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    /// <seealso cref="Core.IInitializationParametersManager{TContainer}" />
    public class InitializationParametersManager<TContainer> : IInitializationParametersManager<TContainer> 
        where TContainer :  new()
    {
        private readonly IInitializationParametersResolutionStrategy<TContainer> _initializationParametersResolutionStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationParametersManager{TContainer}"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public InitializationParametersManager(TContainer container)
        {
            _initializationParametersResolutionStrategy = new InitializationParametersPredefinedResolutionStrategy<TContainer>(container);
        }

        /// <summary>
        /// Gets the initialization parameters.
        /// </summary>
        /// <returns></returns>
        public IInitializationParameters<TContainer> GetInitializationParameters()
        {
            return _initializationParametersResolutionStrategy.GetInitializationParameters();
        }
    }
}
