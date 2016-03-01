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
        /// Builds the fake object.
        /// </summary>
        /// <returns></returns>
        IFake<TService> Build();        
    }
}