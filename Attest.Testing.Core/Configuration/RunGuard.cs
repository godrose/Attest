using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Configuration
{
    /// <summary>
    /// Represents a run guard which is responsible for allowing test/scenario execution.
    /// </summary>
    public class RunGuard : IRunGuard
    {
        private readonly IConfigurationSectionValueProvider _configurationSectionValueProvider;
        private readonly IRunGuardInfo _runGuardInfo;

        /// <summary>
        /// Initializes a new instance of <see cref="RunGuard"/>
        /// </summary>
        /// <param name="configurationSectionValueProvider">The configuration section value provider.</param>
        /// <param name="runGuardInfo">The run guard information.</param>
        public RunGuard(
            IConfigurationSectionValueProvider configurationSectionValueProvider,
            IRunGuardInfo runGuardInfo)
        {
            _configurationSectionValueProvider = configurationSectionValueProvider;
            _runGuardInfo = runGuardInfo;
        }

        /// <inheritdoc />
        public bool CanRun(IConfiguration configuration)
        {
            var runGuardConfiguredValue = _configurationSectionValueProvider.GetValue(
                configuration, 
                _runGuardInfo.Key);
            var canRun = _runGuardInfo.CanRun(runGuardConfiguredValue);
            return canRun;
        }
    }
}