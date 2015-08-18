using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    public interface ICanAddMethods<TService> where TService : class
    {
        IServiceCall<TService> AddMethodCall<TCallback>(IMethodCall<TService, TCallback> methodCall);

        IServiceCall<TService> AddMethodCall<TCallback, TResult>(
            IMethodCallWithResult<TService, TCallback, TResult> methodCall);            
    }

    public interface IHaveNoMethods<TService> : ICanAddMethods<TService> where TService : class
    {
    }

    public interface IAppendMethods<TService> where TService : class
    {
        void AppendMethods(IHaveMethods<TService> otherMethods);
    }

    public interface IHaveMethods<TService> : ICanAddMethods<TService> where TService: class
    {
        IEnumerable<IMethodCallMetaData> MethodCalls { get; }        
    }
}