using System.Collections.Generic;
using Attest.Testing.Modularity;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <inheritdoc />
    public sealed class StaticLifecycleService : ILifecycleService
    {
        private readonly IStaticSetupService _staticSetupService;
        private static Dictionary<int, IStaticApplicationModule> _handlesMap;

        /// <inheritdoc />
        public StaticLifecycleService(IStaticSetupService staticSetupService)
        {
            _staticSetupService = staticSetupService;
        }

        /// <inheritdoc />
        public void Setup()
        {
            _handlesMap = _staticSetupService.OneTimeSetup();
        }

        /// <inheritdoc />
        public void Teardown()
        {
            foreach (var handleEntry in _handlesMap)
            {
                handleEntry.Value.Stop(handleEntry.Key);
            }
        }
    }
}