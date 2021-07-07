using Attest.Fake.Data;
using Attest.Testing.Application;
using Attest.Testing.Lifecycle;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.EndToEnd
{
    /// <summary>
    /// Represents start application service for End-To-End tests.
    /// </summary>
    /// <seealso cref="IStartApplicationService" />
    public abstract class StartApplicationService : IStartApplicationService
    {
        /// <summary>
        /// Represents start application service for End-To-End tests which use fake data providers.
        /// </summary>
        /// <seealso cref="IStartApplicationService" />
        public class WithFakeProviders : StartApplicationService
        {
            private readonly IApplicationFacade _applicationFacade;
            private readonly BuildersCollectionContext _buildersCollectionContext;

            /// <summary>
            /// Initializes a new instance of <see cref="StartApplicationService.WithFakeProviders"/>
            /// </summary>
            /// <param name="applicationFacade"></param>
            /// <param name="buildersCollectionContext"></param>
            public WithFakeProviders(
                IApplicationFacade applicationFacade, 
                BuildersCollectionContext buildersCollectionContext)
            {
                _applicationFacade = applicationFacade;
                _buildersCollectionContext = buildersCollectionContext;
            }

            /// <inheritdoc />
            public override void Start(string startupPath)
            {
                _buildersCollectionContext.SerializeBuilders();
                _applicationFacade.Start(startupPath);
            }
        }

        /// <summary>
        /// Represents start application service for End-To-End tests which use real data providers.
        /// </summary>
        /// <seealso cref="IStartApplicationService" />
        public class WithRealProviders : StartApplicationService
        {
            private readonly IApplicationFacade _applicationFacade;

            /// <summary>
            /// Initializes a new instance of <see cref="StartApplicationService.WithRealProviders"/>
            /// </summary>
            /// <param name="applicationFacade"></param>
            public WithRealProviders(IApplicationFacade applicationFacade)
            {
                _applicationFacade = applicationFacade;
            }

            /// <inheritdoc />
            public override void Start(string startupPath)
            {
                _applicationFacade.Start(startupPath);
            }
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="startupPath">The startup path.</param>
        public abstract void Start(string startupPath);
    }
}
