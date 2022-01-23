using Attest.Testing.Application;
using Attest.Testing.Management;

namespace Attest.Testing.Modularity
{
    /// <summary>
    ///     Represents means for starting a .NET application using CLI
    /// </summary>
    public class DotnetCliApplicationFacade
    {
        private readonly IProcessManagementService _processManagementService;

        /// <summary>
        ///     Creates an instance of <see cref="DotnetCliApplicationFacade" />.
        /// </summary>
        /// <param name="processManagementService">The process management service.</param>
        public DotnetCliApplicationFacade(IProcessManagementService processManagementService)
        {
            _processManagementService = processManagementService;
        }

        /// <summary>
        /// Starts the application using specified path info and options.
        /// </summary>
        /// <param name="applicationPathInfo">The application path info.</param>
        /// <param name="options">The start options.</param>
        /// <returns>The handle(process id) after the application starts.</returns>
        public int Start(IApplicationPathInfo applicationPathInfo, StartCliApplicationModuleOptions options)
        {
            //TODO: Find better location for this functionality
            var optionsPresentation = BuildOptionsPresentation(options);
            var handle = _processManagementService.Start("dotnet", $"{applicationPathInfo.Executable}{optionsPresentation}");
            return handle;
        }

        /// <summary>
        /// Stops the application using the specified handle(process id).
        /// </summary>
        /// <param name="handle">The handle.</param>
        public void Stop(int handle)
        {
            _processManagementService.Stop(handle);
        }

        //TODO: Find better location
        private string BuildOptionsPresentation(StartCliApplicationModuleOptions options)
        {
            var profileOption = string.IsNullOrWhiteSpace(options.Profile)
                ? string.Empty
                : $"--launch-profile {options.Profile}";
            var envOption = string.IsNullOrWhiteSpace(options.Environment)
                ? string.Empty
                : $"--env={options.Environment}";
            return $"{profileOption} {envOption}";
        }
    }
}