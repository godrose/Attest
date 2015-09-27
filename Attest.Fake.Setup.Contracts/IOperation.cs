using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a long-running operation
    /// </summary>
    public interface IOperation
    {
        IOperation WithMethod(Action runMethod);
        IOperation WithCancel(Action onCancel);
        IOperation WithProgress(Action<object> onProgress);
        IOperation WithError(Action<Exception> onError);
        void Start();
        void Cancel();
    }

    /// <summary>
    /// Represents long-running operation associated with a method call on the service
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface IOperation<out TService> : IOperation
    {
        TService Service { get; }
    }

    public interface IOperationFactory
    {
        IOperation<TService> CreateOperation<TService>() where TService : class;
    }    
}
