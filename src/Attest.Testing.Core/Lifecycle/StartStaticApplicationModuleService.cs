using System.IO;
using Attest.Testing.Core;
using Attest.Testing.Modularity;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped once during the whole test/scenario suite execution.
    /// </summary>
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

