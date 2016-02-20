using System;
using System.Collections.Generic;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for fake long-running operations.
    /// </summary>
    public abstract class FakeOperationBase
    {
    }

    /// <summary>
    /// Represents fake long-running operation.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <seealso cref="Attest.Fake.Setup.Contracts.IOperation{TService}" />
    public class FakeOperation<TService> : IOperation<TService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeOperation{TService}"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public FakeOperation(TService service)
        {
            Service = service;
        }

        /// <summary>
        /// Sets the method that is executed when the operation starts to run.
        /// </summary>
        /// <param name="runMethod">The run method.</param>
        /// <returns></returns>
        public IOperation WithMethod(Action runMethod)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the method that is executed when the operation is cancelled.
        /// </summary>
        /// <param name="onCancel">The method to invoke on cancellation.</param>
        /// <returns></returns>
        public IOperation WithCancel(Action onCancel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the method that is executed when the operation yields a progress message.
        /// </summary>
        /// <param name="onProgress">The method to invoke on progress message arrival.</param>
        /// <returns></returns>
        public IOperation WithProgress(Action<object> onProgress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Withes the errorSets the method that is executed when the operation throws an exception.
        /// </summary>
        /// <param name="onError">The method to invoke on exception throwing.</param>
        /// <returns></returns>
        public IOperation WithError(Action<Exception> onError)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the operation.
        /// </summary>
        public void Start()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancels the operation.
        /// </summary>
        public void Cancel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public TService Service { get; private set; }
    }

    /// <summary>
    /// The factory for creating instances of <see cref="IOperation"/>
    /// </summary>
    public class FakeOperationFactory : IOperationFactory
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        /// <summary>
        /// Registers the service call.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="serviceCall">The service call.</param>
        public void RegisterServiceCall<TService>(IServiceCall<TService> serviceCall) where TService : class
        {
            var newServiceType = typeof (TService);
            if (_services.ContainsKey(newServiceType) == false)
            {
                _services.Add(typeof(TService), serviceCall);
            }
            else
            {
                var existingService = _services[newServiceType];
                ((IServiceCall<TService>)existingService).AppendMethods(serviceCall);
            }
        }

        /// <summary>
        /// Creates the operation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public IOperation<TService> CreateOperation<TService>() where TService : class
        {
            var match = _services[typeof (TService)];
            return new FakeOperation<TService>(((IServiceCall<TService>) match).Build().Object);
        }
    }
}
