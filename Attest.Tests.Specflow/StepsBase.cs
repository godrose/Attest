using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Tests.Core;
using Solid.Practices.IoC;

namespace Attest.Tests.Specflow
{
    public abstract class StepsBase<TFakeFactory> where TFakeFactory : IFakeFactory, new()
    {
        protected void RegisterService<TService>(TService service) where TService : class
        {
            IntegrationTestsHelper<TFakeFactory>.RegisterService(GetIocContainer(), service);
        }

        protected void RegisterBuilder<TService>(FakeBuilderBase<TService> builder) where TService : class
        {
            IntegrationTestsHelper<TFakeFactory>.RegisterBuilder(GetIocContainer(), builder);
        }

        protected void RegisterStub<TService>() where TService : class
        {
            IntegrationTestsHelper<TFakeFactory>.RegisterStub<TService>(GetIocContainer());
        }

        protected void RegisterFake<TService>(IFake<TService> fake) where TService : class
        {
            IntegrationTestsHelper<TFakeFactory>.RegisterFake(GetIocContainer(), fake);
        }

        protected void RegisterMock<TService>(IMock<TService> fake) where TService : class
        {
            IntegrationTestsHelper<TFakeFactory>.RegisterMock(GetIocContainer(), fake);
        }

        private static IIocContainer GetIocContainer()
        {
            return (IIocContainer)ScenarioHelper.Container;
        }
    }
}