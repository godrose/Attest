using System.Collections.Generic;
using System.Linq;
using Attest.Testing.Modularity;
using Solid.Core;
using Solid.Practices.IoC;

namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// Represents static setup functionality.
    /// </summary>
    public sealed class StaticSetupService : IStaticSetupService
    {
        private static bool _isOneTimeSetupHandled = false;

        private static Dictionary<int, IStaticApplicationModule> _handlesMap =
            new Dictionary<int, IStaticApplicationModule>();

        private static readonly object OneTimeSetupSyncObject = new object();
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IStartStaticApplicationModuleService _startStaticApplicationModuleService;

        /// <summary>
        /// Initializes a new instance of <see cref="StaticSetupService"/>
        /// </summary>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        /// <param name="startStaticApplicationModuleService">The service for starting collection of static application modules.</param>
        public StaticSetupService(
            IDependencyResolver dependencyResolver,
            IStartStaticApplicationModuleService startStaticApplicationModuleService)
        {
            _dependencyResolver = dependencyResolver;
            _startStaticApplicationModuleService = startStaticApplicationModuleService;
        }

        /// <inheritdoc />
        public Dictionary<int, IStaticApplicationModule> OneTimeSetup()
        {
            lock (OneTimeSetupSyncObject)
            {
                if (_isOneTimeSetupHandled == false)
                {
                    var staticApplicationModules = _dependencyResolver.ResolveAll<IStaticApplicationModule>();
                    var sortedModules = staticApplicationModules.SortTopologically();
                    _handlesMap = sortedModules.ToDictionary(applicationModule =>
                        _startStaticApplicationModuleService.Start(applicationModule));
                    _isOneTimeSetupHandled = true;
                }
                return _handlesMap;
            }
        }
    }
}