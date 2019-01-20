using System.IO;
using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.EndToEnd
{
    /// <inheritdoc />
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

