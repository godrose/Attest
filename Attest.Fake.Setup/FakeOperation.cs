using System;
using System.Collections.Generic;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public abstract class FakeOperationBase
    {
    }

    public class FakeOperation<TService> : IOperation<TService>
    {
        public FakeOperation(TService service)
        {
            Service = service;
        }

        public IOperation WithMethod(Action runMethod)
        {
            throw new NotImplementedException();
        }

        public IOperation WithCancel(Action onCancel)
        {
            throw new NotImplementedException();
        }

        public IOperation WithProgress(Action<object> onProgress)
        {
            throw new NotImplementedException();
        }

        public IOperation WithError(Action<Exception> onError)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public TService Service { get; private set; }
    }

    public class FakeOperationFactory : IOperationFactory
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

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

        public IOperation<TService> CreateOperation<TService>() where TService : class
        {
            var match = _services[typeof (TService)];
            return new FakeOperation<TService>(((IServiceCall<TService>) match).SetupService().Object);
        }
    }
}
