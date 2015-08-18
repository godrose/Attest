namespace Attest.Fake.Setup.Contracts
{
    public interface IServiceCall<TService> : IHaveMethods<TService>, IAppendMethods<TService> where TService : class
    {
        TService GetService();
    }
}