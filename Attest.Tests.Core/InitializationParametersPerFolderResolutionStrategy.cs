using System;
using System.Collections.Concurrent;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    class InitializationParametersPerFolderResolutionStrategy<TBootstrapper, TContainer> : 
        InitializationParametersResolutionStrategyBase<TBootstrapper, TContainer>
        where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {
        private readonly ConcurrentDictionary<string, IInitializationParameters<TBootstrapper, TContainer>>
            _initializationParametersCollection =
                new ConcurrentDictionary<string, IInitializationParameters<TBootstrapper, TContainer>>();

        public override IInitializationParameters<TBootstrapper, TContainer> GetInitializationParameters()
        {
            var currentDirectory = Environment.CurrentDirectory;
            IInitializationParameters<TBootstrapper, TContainer> existingInitializationParameters;
            _initializationParametersCollection.TryGetValue(currentDirectory, out existingInitializationParameters);
            if (existingInitializationParameters == null)
            {
                _initializationParametersCollection.TryAdd(currentDirectory, CreateInitializationParameters());
                return _initializationParametersCollection[currentDirectory];
            }
            else
            {
                return existingInitializationParameters;
            }
        }       
    }
}