using System;
using Attest.Fake.Builders;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Moq.Tests
{
    public delegate void CustomEventHandler(object sender, DataEventArgs e);    

    public class DataEventArgs : EventArgs
    {
        public object Data { get; }

        public DataEventArgs(object data)
        {
            Data = data;
        }
    }    
    
    public interface IEventProvider
    {        
        event EventHandler Arrived;
        event EventHandler<DataEventArgs> DataArrived;
        event CustomEventHandler CustomArrived;
    }

    class EventProviderBuilder : FakeBuilderBase<IEventProvider>.WithInitialSetup
    {
        private EventProviderBuilder()
        {
            
        }

        public static EventProviderBuilder CreateBuilder()
        {
            return new EventProviderBuilder();
        }

        protected override IServiceCall<IEventProvider> CreateServiceCall(
            IHaveNoMethods<IEventProvider> serviceCallTemplate)
        {
            return serviceCallTemplate as IServiceCall<IEventProvider>;
        }

        public EventProviderBuilder RaiseEvent(Action<IEventProvider> eventExpression, EventArgs eventArgs)
        {
            FakeService.Raise(eventExpression, eventArgs);
            return this;
        }

        public EventProviderBuilder RaiseDataEvent(Action<IEventProvider> eventExpression, DataEventArgs eventArgs)
        {
            FakeService.Raise(eventExpression, eventArgs);
            return this;
        }

        public EventProviderBuilder RaiseCustomEvent(Action<IEventProvider> eventExpression, DataEventArgs eventArgs)
        {
            FakeService.Raise(eventExpression, eventArgs);
            return this;
        }
    }

    class FakeEventProvider : IEventProvider
    {
        public event EventHandler Arrived;
        public event EventHandler<DataEventArgs> DataArrived;
        public event CustomEventHandler CustomArrived;

        internal void RaiseDataArrived(object data)
        {
            DataArrived?.Invoke(this, new DataEventArgs(data));
        }
    }
}