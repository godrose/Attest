using Attest.Testing.Contracts;

namespace Attest.Testing.Integration
{
    /// <inheritdoc />
    public sealed class StartLocalApplicationService : IStartLocalApplicationService
    {
        private readonly IStartApplicationService _startApplicationService;

        /// <inheritdoc />
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
