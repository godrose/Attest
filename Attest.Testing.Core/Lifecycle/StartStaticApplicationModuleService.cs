using System.IO;
using Attest.Testing.Core;
using Attest.Testing.Modularity;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    public sealed class StartStaticApplicationModuleService : IStartStaticApplicationModuleService
    {
        /// <inheritdoc />
        public int Start(IStaticApplicationModule applicationModule)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var relativePath = applicationModule.RelativePath;            
            PathHelper.EnsurePath(currentDirectory, relativePath);
            var handle = applicationModule.Start();
            Directory.SetCurrentDirectory(currentDirectory);
            return handle;
        }
    }
}

