using Attest.Testing.Execution;
using Attest.Testing.Reporting;
using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

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
            //TODO: Split registration into Modules
            var configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource
            {
                Path = "./appsettings.json"
            }).Build();
            _container.RegisterInstanceAs<IConfiguration>(configuration);
            _container.RegisterTypeAs<AtlassianConfigurationProvider, AtlassianConfigurationProvider>();
            _container.RegisterTypeAs<ReportConfigurationProvider, ReportConfigurationProvider>();
            _container.RegisterTypeAs<ConfluenceProvider, ConfluenceProvider>();
            _container.RegisterTypeAs<ConfluenceContentsFactory, ConfluenceContentsFactory>();
            _container.RegisterTypeAs<ConfluenceStatusUpdater, ConfluenceStatusUpdater>();
            _container.RegisterTypeAs<DescriptionContentFactory, DescriptionContentFactory>();
            _container.RegisterTypeAs<FileSystemSpecsInfo, ISpecsInfo>();
        }
    }
}
