using Attest.Testing.Contracts;
using Attest.Testing.Core.FakeData.Shared;

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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="applicationFacade"></param>
            public WithFakeProviders(IApplicationFacade applicationFacade)
            {
                _applicationFacade = applicationFacade;
            }
            /// <summary>
            /// Starts the application.
            /// </summary>
            /// <param name="startupPath">The startup path.</param>
            public override void StartApplication(string startupPath)
            {
                BuildersCollectionContext.SerializeBuilders();
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
            /// 
            /// </summary>
            /// <param name="applicationFacade"></param>
            public WithRealProviders(IApplicationFacade applicationFacade)
            {
                _applicationFacade = applicationFacade;
            }
            /// <summary>
            /// Starts the application.
            /// </summary>
            /// <param name="startupPath">The startup path.</param>
            public override void StartApplication(string startupPath)
            {
                _applicationFacade.Start(startupPath);
            }
        }

        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="startupPath">The startup path.</param>
        public abstract void StartApplication(string startupPath);
    }
}
