using System;
using Attest.Fake.Core;
using FluentAssertions;
using Xunit;

namespace Attest.Fake.Moq.Tests
{
    public class EventInvocationTests
    {
        static EventInvocationTests()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }

        [Fact]
        public void Raise_EventIsRaised()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            EventArgs arrivedArgs = null;
            instance.Arrived += (sender, args) => arrivedArgs = args;
            
            var argsTobeSent = new EventArgs();
            eventProviderBuilder.RaiseEvent(m => m.Arrived += null, argsTobeSent);

            arrivedArgs.Should().BeSameAs(argsTobeSent);
        }

        [Fact]
        public void RaiseData_DataEventIsRaised()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;            
            DataEventArgs arrivedArgs = null;
            instance.DataArrived += (sender, args) => arrivedArgs = args;

            var argsTobeSent = new DataEventArgs(new object());
            eventProviderBuilder.RaiseDataEvent(m => m.DataArrived += null, argsTobeSent);

            arrivedArgs.Should().BeSameAs(argsTobeSent);
        }

        [Fact]
        public void RaiseCustom_CustomEventIsRaised()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            DataEventArgs arrivedArgs = null;
            instance.CustomArrived += (sender, args) => arrivedArgs = args;

            var argsTobeSent = new DataEventArgs(new object());
            eventProviderBuilder.RaiseCustomEvent(m => m.CustomArrived += null, argsTobeSent);

            arrivedArgs.Should().BeSameAs(argsTobeSent);
        }        
    }
}
