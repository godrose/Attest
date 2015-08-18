using System;

namespace Attest.Fake.Setup.Contracts
{

    public interface IOperation
    {
        IOperation WithMethod(Action runMethod);
        IOperation WithCancel(Action onCancel);
        IOperation WithProgress(Action<object> onProgress);
        IOperation WithError(Action<Exception> onError);
        void Start();
        void Cancel();
    }

    public interface IOperation<out TService> : IOperation
    {
        TService Service { get; }
    }

    public interface IOperationFactory
    {
        IOperation<TService> CreateOperation<TService>() where TService : class;
    }    
}
