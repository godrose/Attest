using Attest.Fake.Builders;
using Attest.Fake.Moq;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Tests
{
    public class LoginProviderBuilder : FakeBuilderBase<ILoginProvider>
    {
        private bool _isLoggedIn;

        private LoginProviderBuilder()
        {
            
        }

        public static LoginProviderBuilder CreateBuilder()
        {
            return new LoginProviderBuilder();
        }

        private IHaveNoMethods<ILoginProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        protected override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();

            var setup = initialSetup.AddMethodCallAsync(t => t.Login(), r => r.Complete(Login));

            setup.AddMethodCallAsync<string>(t => t.LoginWithOneParameter(It.IsAny<string>()), r => r.Complete(Login));

            setup.Build();

            FakeService.Setup(t => t.IsLoggedIn).Callback(() => _isLoggedIn);
        }

        private void Login()
        {
            _isLoggedIn = true;
        }

        private void Login(string parameter)
        {
            _isLoggedIn = true;
        }
    }
}