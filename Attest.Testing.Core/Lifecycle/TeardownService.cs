using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Lifecycle
{
    /// <summary>
    /// The basic teardown service which stops the running application.
    /// </summary>
    public sealed class TeardownService : ITeardownService
    {
        private readonly IApplicationFacade _applicationFacade;

        /// <summary>
        /// Creates new instance of <see cref="TeardownService"/>
        /// </summary>
        /// <param name="applicationFacade"></param>
        public TeardownService(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        /// <inheritdoc />       
        public void Teardown()
        {
            _applicationFacade.Stop();
        }
    }
}
