using System.Collections.Generic;
using Attest.Fake.Core;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Sets up service fakes 
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IServiceSetupFactory<TService> where TService : class
    {
        /// <summary>
        /// Sets up service fake using provided list of method calls
        /// </summary>
        /// <param name="fake">Initial fake</param>
        /// <param name="methodCalls">List of method calls</param>
        /// <returns>Fake after the setup</returns>
        IFake<TService> SetupFakeService(IFake<TService> fake, IEnumerable<IMethodCallMetaData> methodCalls);
    }
}