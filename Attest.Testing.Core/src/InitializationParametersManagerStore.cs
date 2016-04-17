using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Allows returning <see cref="IInitializationParametersManager{TContainer}"/> according to the resolution style.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    public static class ContainerInitializationParametersManagerStore<TBootstrapper, TContainer>                 
        where TBootstrapper : IInitializable, IHaveContainer<TContainer>, new()
    {
        private static Dictionary
            <InitializationParametersResolutionStyle, IInitializationParametersManager<TContainer>>
            _internalStorage;

        private static Dictionary<InitializationParametersResolutionStyle, IInitializationParametersManager<TContainer>> InitializeDictionary()
        {            
            var enums =
                Enum.GetValues(typeof (InitializationParametersResolutionStyle))
                    .OfType<InitializationParametersResolutionStyle>()
                    .ToArray();
            return enums.ToDictionary(t => t,
                t =>
                    (IInitializationParametersManager<TContainer>)
                        new ContainerInitializationParametersManager<TBootstrapper, TContainer>(t));
        }

        /// <summary>
        /// Gets the initialization parameters manager.
        /// </summary>
        /// <param name="resolutionStyle">The resolution style.</param>
        /// <returns></returns>
        public static IInitializationParametersManager<TContainer> 
            GetInitializationParametersManager(
            InitializationParametersResolutionStyle resolutionStyle)
        {
            if (_internalStorage == null)
            {
                _internalStorage = InitializeDictionary();
            }
            IInitializationParametersManager<TContainer> value;
            _internalStorage.TryGetValue(resolutionStyle, out value);
            return value;
        }        
    }

    /// <summary>
    /// Allows returning <see cref="IInitializationParametersManager{TContainer}"/> according to the resolution style.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainerAdapter">The type of the container.</typeparam>
    public static class ContainerAdapterInitializationParametersManagerStore<TBootstrapper, TContainerAdapter>
        where TBootstrapper : IInitializable, IHaveContainerAdapter<TContainerAdapter>, new() 
        where TContainerAdapter : IIocContainer
    {
        private static Dictionary
            <InitializationParametersResolutionStyle, IInitializationParametersManager<TContainerAdapter>>
            _internalStorage;

        private static Dictionary<InitializationParametersResolutionStyle, IInitializationParametersManager<TContainerAdapter>> InitializeDictionary()
        {
            var enums =
                Enum.GetValues(typeof(InitializationParametersResolutionStyle))
                    .OfType<InitializationParametersResolutionStyle>()
                    .ToArray();
            return enums.ToDictionary(t => t,
                t =>
                    (IInitializationParametersManager<TContainerAdapter>)
                        new ContainerAdapterInitializationParametersManager<TBootstrapper, TContainerAdapter>(t));
        }

        /// <summary>
        /// Gets the initialization parameters manager.
        /// </summary>
        /// <param name="resolutionStyle">The resolution style.</param>
        /// <returns></returns>
        public static IInitializationParametersManager<TContainerAdapter>
            GetInitializationParametersManager(
            InitializationParametersResolutionStyle resolutionStyle)
        {
            if (_internalStorage == null)
            {
                _internalStorage = InitializeDictionary();
            }
            IInitializationParametersManager<TContainerAdapter> value;
            _internalStorage.TryGetValue(resolutionStyle, out value);
            return value;
        }
    }
}
