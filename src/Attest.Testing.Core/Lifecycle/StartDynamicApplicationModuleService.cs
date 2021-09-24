using System.IO;
using Attest.Testing.Core;
using Attest.Testing.Modularity;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents means of starting an application
    /// that is started and stopped during the test/scenario execution.
    /// </summary>
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