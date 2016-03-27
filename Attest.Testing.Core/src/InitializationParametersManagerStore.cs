using System;
using System.Collections.Generic;
using System.Linq;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Allows returning <see cref="IInitializationParametersManager{TContainer}"/> according to the resolution style.
    /// </summary>
    /// <typeparam name="TBootstrapper">The type of the bootstrapper.</typeparam>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
    public static class InitializationParametersManagerStore<TBootstrapper, TContainer>         
        where TContainer : new()
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
                        new InitializationParametersManager<TBootstrapper, TContainer>(t, BootstrapperInit ?? (c => { })));
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

        /// <summary>
        /// Gets or sets the bootstrapper initialize logic.
        /// </summary>
        /// <value>
        /// The bootstrapper initialize logic.
        /// </value>
        public static Action<TBootstrapper> BootstrapperInit { get; set; }
    }
}
