using System.Collections.Generic;
using System.Linq;
using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Attest.Testing.EndToEnd
{
    /// <inheritdoc />
    public sealed class StaticSetupService : IStaticSetupService
    {
        private static bool _isOneTimeSetupHandled = false;

        private static Dictionary<int, IStaticApplicationModule> _handlesMap =
            new Dictionary<int, IStaticApplicationModule>();

        private static readonly object OneTimeSetupSyncObject = new object();
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IStartStaticApplicationModuleService _startApplicationModuleService;

        /// <inheritdoc />
        public StaticSetupService(
            IDependencyResolver dependencyResolver,
            IStartStaticApplicationModuleService startApplicationModuleService)
        {
            _dependencyResolver = dependencyResolver;
            _startApplicationModuleService = startApplicationModuleService;
        }

        /// <inheritdoc />
        public Dictionary<int, IStaticApplicationModule> OneTimeSetup()
        {
            lock (OneTimeSetupSyncObject)
            {
                if (_isOneTimeSetupHandled == false)
                {
                    var staticApplicationModules = _dependencyResolver.ResolveAll<IStaticApplicationModule>();
                    _handlesMap = staticApplicationModules.ToDictionary(applicationModule =>
                        _startApplicationModuleService.Start(applicationModule));
                    _isOneTimeSetupHandled = true;
                }
                return _handlesMap;
            }
        }
    }
}