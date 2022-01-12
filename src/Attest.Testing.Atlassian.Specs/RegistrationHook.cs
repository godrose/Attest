using Attest.Testing.Execution;
using BoDi;

namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    internal class RegistrationHook
    {
        private readonly IObjectContainer _container;

        public RegistrationHook(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void RegisterDependencies()
        {
            _container.RegisterTypeAs<WorkflowHelper, WorkflowHelper>();
            _container.RegisterTypeAs<ConfluenceContentsFactory, ConfluenceContentsFactory>();
            _container.RegisterTypeAs<ConfluenceStatusUpdater, ConfluenceStatusUpdater>();
            _container.RegisterTypeAs<FileSystemSpecsInfo, ISpecsInfo>();
            _container.RegisterTypeAs<RestClientFactory, RestClientFactory>();
        }
    }
}
