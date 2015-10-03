using System;
using System.Collections.Concurrent;
using Solid.Practices.IoC;

namespace Attest.Tests.Core
{
    class BootstrapperPerFolderResolutionStrategy<TBootstrapper, TContainer> : 
        BootstrapperResolutionStrategyBase<TBootstrapper, TContainer>
        where TBootstrapper : new()
        where TContainer : IIocContainer, new()
    {        
        private readonly ConcurrentDictionary<string, TBootstrapper> _bootstrappers = 
            new ConcurrentDictionary<string, TBootstrapper>();

        public override TBootstrapper GetBootstrapper()
        {
            var currentDirectory = Environment.CurrentDirectory;
            TBootstrapper existingBootstrapper;
            _bootstrappers.TryGetValue(currentDirectory, out existingBootstrapper);
            if (existingBootstrapper == null)
            {
                _bootstrappers.TryAdd(currentDirectory, CreateBootstrapper());
                return _bootstrappers[currentDirectory];
            }
            else
            {
                return existingBootstrapper;
            }
        }       
    }
}