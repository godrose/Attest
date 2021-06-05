using Attest.Testing.Contracts;
using Solid.Bootstrapping;
using Solid.Practices.Middleware;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Management
{
    /// <summary>
    /// This middleware registers dependencies for the process management.
    /// </summary>
    /// <typeparam name="TProcessManagementService">The type of the process management service.</typeparam>
    public sealed class UseManagementMiddleware<TProcessManagementService> : IMiddleware<IHaveRegistrator>
        where TProcessManagementService : class, IProcessManagementService
    {
        /// <inheritdoc />
        public IHaveRegistrator Apply(IHaveRegistrator @object)
        {
            @object.Registrator.UseManagement<TProcessManagementService>();
            return @object;
        }
    }
}
