using System.IO;
using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.EndToEnd
{
    /// <summary>
    /// Represents an implementation of <see cref="IStartDynamicApplicationModuleService"/> 
    /// for end-to-end tests.
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