using System.Collections.Generic;
using Attest.Testing.Modularity;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents a service which manages lifecycle for a collection of <see cref="IStaticApplicationModule"/>.
    /// </summary>
    public sealed class StaticLifecycleService : ILifecycleService
    {
        private readonly IStaticSetupService _staticSetupService;
        private static Dictionary<int, IStaticApplicationModule> _handlesMap;

        /// <summary>
        /// Initializes a new instance of <see cref="StaticLifecycleService"/>
        /// </summary>
        /// <param name="staticSetupService">The setup service for static application modules.</param>
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