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
        public void StartApplication()
        {
            _startApplicationService.StartApplication(string.Empty);
        }
    }
}
