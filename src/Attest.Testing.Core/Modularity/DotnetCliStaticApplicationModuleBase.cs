using Attest.Testing.Application;
using Attest.Testing.Management;

namespace Attest.Testing.Modularity
{
    /// <summary>
    /// Represents a static application module that can be started via dotnet CLI.
    /// </summary>
    public abstract class DotnetCliStaticApplicationModuleBase : IStaticApplicationModule
    {
        private readonly DotnetCliApplicationFacade _applicationFacade;

        /// <summary>
        /// Creates an instance of <see cref="DotnetCliStaticApplicationModuleBase" />.
        /// </summary>
        /// <param name="processManagementService">The process management service.</param>
        protected DotnetCliStaticApplicationModuleBase(IProcessManagementService processManagementService)
        {
            _applicationFacade = new DotnetCliApplicationFacade(processManagementService);
        }

        /// <summary>
        /// Override to provide application module's identifier.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Override to provide application module's custom relative path.
        /// </summary>
        public string RelativePath => PathInfo.RelativePath;

        /// <summary>
        /// Override to provide application module's path info.
        /// </summary>
        protected abstract IApplicationPathInfo PathInfo { get; }

        /// <summary>
        /// Override to use custom start options for application module.
        /// </summary>
        protected virtual StartCliApplicationModuleOptions StartOptions => new StartCliApplicationModuleOptions();

        /// <summary>
        /// Starts the application module.
        /// </summary>
        /// <returns></returns>
        public int Start()
        {
            var handle = _applicationFacade.Start(PathInfo, StartOptions);
            StartOverride(handle);
            return handle;
        }

        /// <summary>
        /// Stops the application module.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public virtual void Stop(int handle)
        {
            _applicationFacade.Stop(handle);
        }

        /// <summary>
        /// Override to inject custom logic during application module's start.
        /// </summary>
        /// <param name="handle">The handle.</param>
        protected virtual void StartOverride(int handle)
        {

        }
    }
}