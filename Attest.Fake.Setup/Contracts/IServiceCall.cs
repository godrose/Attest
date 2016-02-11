using Attest.Fake.Core;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a list of method calls on a specific type of service.
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface IServiceCall<TService> : IHaveMethods<TService>, IAppendMethods<TService> where TService : class
    {
        /// <summary>
        /// Sets the service calls and returns the fake object as its proxy.
        /// </summary>
        /// <returns></returns>
        IFake<TService> SetupService();
    }
}