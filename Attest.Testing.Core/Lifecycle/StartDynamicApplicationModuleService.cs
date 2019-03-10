using System.IO;
using Attest.Testing.Contracts;
using Attest.Testing.Core;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <inheritdoc />
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