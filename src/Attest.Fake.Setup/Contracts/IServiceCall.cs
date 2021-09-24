using Attest.Fake.Core;
using Solid.Patterns.Builder;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a list of method calls on a specific type of service.
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface IServiceCall<TService> : IHaveMethods<TService>, IAppendMethods<TService>,
        IBuilder<IFake<TService>> where TService : class
    {
    }
}