using System.Threading.Tasks;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Tests
{
    public interface ILoginProvider
    {
        bool IsLoggedIn();

        Task Login();
        Task LoginWithOneParameter(string parameter);
        Task LoginWithTwoParameters(string firstParameter, string secondParameter);
        Task LoginWithThreeParameters(string firstParameter, string secondParameter, string thirdParameter);

        Task LoginWithFourParameters(string firstParameter, string secondParameter, string thirdParameter,
            string fourthParameter);

        Task LoginWithFiveParameters(string firstParameter, string secondParameter, string thirdParameter,
            string fourthParameter, string fifthParameter);
    }

    public class LoginProviderBuilder : FakeBuilderBase<ILoginProvider>.WithInitialSetup
    {
        private bool _isLoggedIn;        

        private LoginProviderBuilder()
        {
            
        }

        public static LoginProviderBuilder CreateBuilder()
        {
            return new LoginProviderBuilder();
        }

        protected override IServiceCall<ILoginProvider> CreateServiceCall(IHaveNoMethods<ILoginProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate.AddMethodCallAsync(t => t.Login(), r => r.Complete(Login));

            setup.AddMethodCallAsync<string>(t => t.LoginWithOneParameter(It.IsAny<string>()), r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string>(
                t => t.LoginWithTwoParameters(It.IsAny<string>(), It.IsAny<string>()), r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string>(
                t => t.LoginWithThreeParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string, string>(
                t =>
                    t.LoginWithFourParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete(Login));

            setup.AddMethodCallAsync<string, string, string, string, string>(
                t =>
                    t.LoginWithFiveParameters(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                r => r.Complete(Login));

            setup.AddMethodCallWithResult(t => t.IsLoggedIn(), r => r.Complete(() => _isLoggedIn));

            return setup;
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