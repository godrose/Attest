using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Integration
{
    /// <inheritdoc />
    public sealed class StartLocalApplicationService : IStartLocalApplicationService
    {
        private readonly IStartApplicationService _startApplicationService;

        /// <summary>
        /// Initializes a new instance of <see cref="StartLocalApplicationService"/>.
        /// </summary>
        /// <param name="startApplicationService"></param>
        public StartLocalApplicationService(IStartApplicationService startApplicationService)
        {
            _startApplicationService = startApplicationService;
        }

        /// <inheritdoc />
        public void Start()
        {
            _startApplicationService.Start(string.Empty);
        }
    }
}
