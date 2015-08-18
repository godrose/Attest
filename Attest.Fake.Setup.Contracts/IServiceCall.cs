using Attest.Fake.Core;

namespace Attest.Fake.Setup.Contracts
{
    public interface IServiceCall<TService> : IHaveMethods<TService>, IAppendMethods<TService> where TService : class
    {
        IFake<TService> SetupService();
    }
}