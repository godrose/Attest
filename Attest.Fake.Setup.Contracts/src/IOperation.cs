using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents a long-running operation
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Sets the method that is executed when the operation starts to run.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        IOperation WithMethod(Action runMethod);
        /// <summary>
        /// Sets the method that is executed when the operation is cancelled.
        /// </summary>
        /// <param name="onCancel">The on cancel.</param>
        /// <returns></returns>
        IOperation WithCancel(Action onCancel);
        /// <summary>
        /// Sets the method that is executed when the operation yields a progress message.
        /// </summary>
        /// <param name="onProgress">The on progress.</param>
        /// <returns></returns>
        IOperation WithProgress(Action<object> onProgress);
        /// <summary>
        /// Withes the errorSets the method that is executed when the operation throws an exception.
        /// </summary>
        /// <param name="onError">The on error.</param>
        /// <returns></returns>
        IOperation WithError(Action<Exception> onError);
        /// <summary>
        /// Starts the operation.
        /// </summary>
        void Start();
        /// <summary>
        /// Cancels the operation.
        /// </summary>
        void Cancel();
    }

    /// <summary>
    /// Represents long-running operation associated with a method call on the service
    /// </summary>
    /// <typeparam name="TService">Type of service</typeparam>
    public interface IOperation<out TService> : IOperation
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        TService Service { get; }
    }

    /// <summary>
    /// The operation factory.
    /// </summary>
    public interface IOperationFactory
    {
        /// <summary>
        /// Creates the operation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        IOperation<TService> CreateOperation<TService>() where TService : class;
    }    
}
