using System.Collections.Generic;
using Attest.Fake.Core;

namespace Attest.Fake.Setup.Contracts
{
    public interface IServiceSetupFactory<TService> where TService : class
    {
        IFake<TService> SetupFakeService(IFake<TService> fake, IEnumerable<object> methodCalls);
    }
}