using System.IO;
using Attest.Testing.Contracts;

namespace Attest.Testing.EndToEnd
{
    /// <summary>
    /// Represents an implementation of <see cref="IStartApplicationModuleService"/> 
    /// for end-to-end tests.
    /// </summary>
    public sealed class StartApplicationModuleService : IStartApplicationModuleService
    {
        /// <inheritdoc />
        public void StartApplication(IApplicationModule applicationModule)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            PathHelper.EnsurePath(currentDirectory, applicationModule.RelativePath);
            applicationModule.StartApplication();
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }
}