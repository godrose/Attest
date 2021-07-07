using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    public interface IRunGuard
    {
        bool CanRun(IConfiguration configuration);
    }
}