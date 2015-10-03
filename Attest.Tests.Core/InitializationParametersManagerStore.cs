using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    public static class InitializationParametersManagerStore<TBootstrapper, TContainer>         
        where TContainer : IIocContainer, new()
    {
        private static readonly Dictionary
                <InitializationParametersResolutionStyle, IInitializationParametersManager<TBootstrapper, TContainer>>
            InternalStorage =
                InitializeDictionary();

        private static Dictionary<InitializationParametersResolutionStyle, IInitializationParametersManager<TBootstrapper, TContainer>> InitializeDictionary()
        {            
            var enums =
                Enum.GetValues(typeof (InitializationParametersResolutionStyle))
                    .OfType<InitializationParametersResolutionStyle>()
                    .ToArray();
            return enums.ToDictionary(t => t,
                t =>
                    (IInitializationParametersManager<TBootstrapper, TContainer>)
                        new InitializationParametersManager<TBootstrapper, TContainer>(t));
        }

        public static IInitializationParametersManager<TBootstrapper, TContainer> 
            GetInitializationParametersManager(
            InitializationParametersResolutionStyle resolutionStyle)
        {
            IInitializationParametersManager<TBootstrapper, TContainer> value;
            InternalStorage.TryGetValue(resolutionStyle, out value);
            return value;
        }
    }
}
