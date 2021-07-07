using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    public class RunGuard : IRunGuard
    {
        private readonly IConfigurationSectionValueProvider _configurationSectionValueProvider;
        private readonly IRunGuardInfo _runGuardInfo;

        public RunGuard(
            IConfigurationSectionValueProvider configurationSectionValueProvider,
            IRunGuardInfo runGuardInfo)
        {
            _configurationSectionValueProvider = configurationSectionValueProvider;
            _runGuardInfo = runGuardInfo;
        }

        public bool CanRun(IConfiguration configuration)
        {
            var runGuardConfiguredValue = _configurationSectionValueProvider.GetValue(configuration, _runGuardInfo.Key);
            var canRun = _runGuardInfo.CanRun(runGuardConfiguredValue);
            return canRun;
        }
    }
}