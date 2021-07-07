using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Configuration
{
    public interface IRunGuard
    {
        bool CanRun(IConfiguration configuration);
    }
}