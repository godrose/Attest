using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Attest.Fake.LightMock;
using FluentAssertions;
using LightMock;
using Xunit;

namespace Attest.Fake.Setup.Tests
{
    public interface ILoginProvider2
    {
        void Login(string username, string password);
        void AddUser(string username, string password);
        string[] GetUsers();
    }

    public class LightMockLoginProviderBuilder : FakeBuilderBase<ILoginProvider2>
    {
        class LoginProviderProxy : ProviderProxyBase<ILoginProvider2>, ILoginProvider2
        {
            public LoginProviderProxy(IInvocationContext<ILoginProvider2> context)
                : base(context)
            {
            }

            public void Login(string username, string password)
            {
                Invoke(t => t.Login(username, password));
            }

            public void AddUser(string username, string password)
            {
                Invoke(t => t.AddUser(username, password));
            }

            public string[] GetUsers()
            {
                return Invoke(t => t.GetUsers());
            }
        }

        private readonly List<Tuple<string, string>> _users = new List<Tuple<string, string>>();
        private readonly Dictionary<string, bool> _isLoginAttemptSuccessfulCollection = new Dictionary<string, bool>();

        private LightMockLoginProviderBuilder()
            : base(FakeFactoryHelper.CreateFake<ILoginProvider2>(c => new LoginProviderProxy(c)))
        {

        }

        public static LightMockLoginProviderBuilder CreateBuilder()
        {
            return new LightMockLoginProviderBuilder();
        }

        public void WithUser(string username, string password)
        {
            _users.Add(new Tuple<string, string>(username, password));
        }

        protected override void SetupFake()
        {
            var initialSetup = ServiceCallFactory.CreateServiceCall(FakeService);

            var setup = initialSetup
                .AddMethodCall<string, string>(t => t.Login(The<string>.IsAnyValue, The<string>.IsAnyValue),
                    (r, login, password) =>
                        _isLoginAttemptSuccessfulCollection.ContainsKey(login)
                            ? _isLoginAttemptSuccessfulCollection[login]
                                ? r.Complete()
                                : r.Throw(new Exception("unable to login"))
                            : r.Throw(new Exception("unable to login")))
                .AddMethodCallWithResult(t => t.GetUsers(), r => r.Complete(_users.Select(k => k.Item1).ToArray))
                .AddMethodCall<string ,string>(t => t.AddUser(The<string>.IsAnyValue, The<string>.IsAnyValue), (r, u, p) =>
                {

                    return r.Complete((username, password) =>
                    {

                        _isLoginAttemptSuccessfulCollection.Add(username, true);
                        _users.Add(new Tuple<string, string>(username, password));
                    });
                });

            setup.Build();
        }

        public void WithSuccessfulLogin(string username)
        {
            _isLoginAttemptSuccessfulCollection[username] = true;
        }
    }

    class FakeLoginProvider : FakeProviderBase<LightMockLoginProviderBuilder, ILoginProvider2>, ILoginProvider2
    {
        private readonly LightMockLoginProviderBuilder _loginProviderBuilder;

        public FakeLoginProvider(
            LightMockLoginProviderBuilder loginProviderBuilder
            )
        {
            _loginProviderBuilder = loginProviderBuilder;
            loginProviderBuilder.WithUser("Vasya", null);
            loginProviderBuilder.WithUser("Petya", null);
        }

        void ILoginProvider2.Login(string username, string password)
        {
            var service = GetService(() => _loginProviderBuilder, b => b);
            service.Login(username, password);
        }

        void ILoginProvider2.AddUser(string username, string password)
        {
            var service = GetService(() => _loginProviderBuilder, b => b);
            service.AddUser(username, password);
        }

        string[] ILoginProvider2.GetUsers()
        {
            var service = GetService(() => _loginProviderBuilder, b => b);
            return service.GetUsers();
        }
    }

    public class MultipleCallsLightMockTests
    {        
        [Fact]
        public void MultipleCalls_ResultIsSetAsFunction_ResultsAreDifferent()
        {            
            var loginProviderBuilder = LightMockLoginProviderBuilder.CreateBuilder();
            
            ILoginProvider2 provider = new FakeLoginProvider(loginProviderBuilder);
            var firstUsers = provider.GetUsers();
            provider.AddUser("Kolya", null);
            var secondUsers = provider.GetUsers();
            secondUsers.Should().NotBeEquivalentTo(firstUsers);            
        }        
    }
}