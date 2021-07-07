using System.IO;
using Attest.Testing.Core;
using Attest.Testing.Modularity;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    public sealed class StartDynamicApplicationModuleService : IStartDynamicApplicationModuleService
    {
        /// <inheritdoc />
        public void Start(IDynamicApplicationModule applicationModule)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            PathHelper.EnsurePath(currentDirectory, applicationModule.RelativePath);
            applicationModule.Start();
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }
}