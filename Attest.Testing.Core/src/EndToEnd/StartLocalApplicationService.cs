using System.IO;
using Attest.Testing.Contracts;

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
        public void StartApplication()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var appDir = Path.Combine(currentDirectory, _applicationPathInfo.RelativePath);
            if (Directory.Exists(appDir) == false)
            {
                Directory.CreateDirectory(appDir);
            }
            Directory.SetCurrentDirectory(appDir);
            _startApplicationService.StartApplication(_applicationPathInfo.Executable);
            Directory.SetCurrentDirectory(currentDirectory);
        }
    }
}
