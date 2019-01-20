using System.IO;
using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.EndToEnd
{
    /// <inheritdoc />
    public sealed class StartLocalApplicationService : IStartLocalApplicationService
    {
        private readonly IStartApplicationService _startApplicationService;
        private readonly IApplicationPathInfo _applicationPathInfo;

        /// <summary>
        /// Creates a new instance of <see cref="StartLocalApplicationService"/>
        /// </summary>
        /// <param name="startApplicationService"></param>
        /// <param name="applicationPathInfo"></param>
        public StartLocalApplicationService(
            IStartApplicationService startApplicationService,
            IApplicationPathInfo applicationPathInfo)
        {
            _startApplicationService = startApplicationService;
            _applicationPathInfo = applicationPathInfo;
        }

        /// <inheritdoc />
        public void Start()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            PathHelper.EnsurePath(currentDirectory, _applicationPathInfo.RelativePath);
            _startApplicationService.Start(_applicationPathInfo.Executable);
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }
}
