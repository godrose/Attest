using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a method calls container.
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IHaveMethods<TService> : ICanAddMethods<TService>, ICanAddMethodsEx<TService> where TService: class
    {
        /// <summary>
        /// Collection of method calls.
        /// </summary>
        IEnumerable<IMethodCallMetaData> MethodCalls { get; }        
    }
}