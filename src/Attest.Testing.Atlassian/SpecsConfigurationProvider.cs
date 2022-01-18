using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Atlassian
{
    public class SpecsConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public SpecsConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string RootDir => _configuration.GetSection("Specs").GetSection(nameof(RootDir)).Value;
    }
}