using Attest.Fake.Builders;
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
            
            setup.AddMethodCallAsync<string>(t => t.LoginWithOneParameter(ConstraintFactoryWrapper.It.IsAny<string>()), r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string>(
                t => t.LoginWithTwoParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()), r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string>(
                t => t.LoginWithThreeParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
                r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string, string>(
                t =>
                    t.LoginWithFourParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
                r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string, string, string>(
                t =>
                    t.LoginWithFiveParameters(ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>(), ConstraintFactoryWrapper.It.IsAny<string>()),
                r => r.Complete(Login));

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

        private void Login(string firstParameter, string secondParameter)
        {
            _isLoggedIn = true;
        }

        private void Login(string firstParameter, string secondParameter, string thirdParameter)
        {
            _isLoggedIn = true;
        }

        private void Login(string firstParameter, string secondParameter, string thirdParameter, string fourthParameter)
        {
            _isLoggedIn = true;
        }

        private void Login(string firstParameter, string secondParameter, string thirdParameter, string fourthParameter, string fifthParameter)
        {
            _isLoggedIn = true;
        }
    }
}