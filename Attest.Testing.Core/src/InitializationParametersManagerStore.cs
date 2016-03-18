using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Allows returning <see cref="IInitializationParametersManager{TContainer}"/> according to the resolution style.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    public static class InitializationParametersManagerStore<TBootstrapper, TContainer>         
        where TContainer : IIocContainer, new()
    {
        private static readonly Dictionary
                <InitializationParametersResolutionStyle, IInitializationParametersManager<TContainer>>
            InternalStorage =
                InitializeDictionary();

        private static Dictionary<InitializationParametersResolutionStyle, IInitializationParametersManager<TContainer>> InitializeDictionary()
        {            
            var enums =
                Enum.GetValues(typeof (InitializationParametersResolutionStyle))
                    .OfType<InitializationParametersResolutionStyle>()
                    .ToArray();
            return enums.ToDictionary(t => t,
                t =>
                    (IInitializationParametersManager<TContainer>)
                        new InitializationParametersManager<TBootstrapper, TContainer>(t));
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
            IInitializationParametersManager<TContainer> value;
            InternalStorage.TryGetValue(resolutionStyle, out value);
            return value;
        }
    }
}
