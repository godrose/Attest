using System;
using Attest.Fake.Core;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Attest.Fake.Moq.Tests
{
    [Binding]
    internal sealed class EventInvocationStepsAdapter
    {
        //TODO: Use Container
        private readonly ScenarioContext _scenarioContext;

        public EventInvocationStepsAdapter(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Moq setup is used")]
        public void GivenMoqSetupIsUsed()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }

        [Given(@"The Arrived event is to be tested")]
        public void GivenTheArrivedEventIsToBeTested()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            var arrivedArgs = new WeakReference<EventArgs>(null);
            instance.Arrived += (sender, args) => arrivedArgs.SetTarget(args);
            _scenarioContext.Add("providerBuilder", eventProviderBuilder);
            _scenarioContext.Add("arrivedArgsRef", arrivedArgs);
        }

        [Given(@"The Data Arrived event is to be tested")]
        public void GivenTheDataArrivedEventIsToBeTested()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            var arrivedArgs = new WeakReference<DataEventArgs>(null);
            instance.DataArrived += (sender, args) => arrivedArgs.SetTarget(args);
            _scenarioContext.Add("providerBuilder", eventProviderBuilder);
            _scenarioContext.Add("arrivedArgsRef", arrivedArgs);
        }

        [Given(@"The Custom event is to be tested")]
        public void GivenTheCustomEventIsToBeTested()
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            var arrivedArgs = new WeakReference<DataEventArgs>(null);
            instance.CustomArrived += (sender, args) => arrivedArgs.SetTarget(args);
            _scenarioContext.Add("providerBuilder", eventProviderBuilder);
            _scenarioContext.Add("arrivedArgsRef", arrivedArgs);
        }


        [When(@"I simulate Arrived event")]
        public void WhenISimulateArrivedEvent()
        {
            var argsToBeSent = new EventArgs();
            var providerBuilder = _scenarioContext.Get<EventProviderBuilder>("providerBuilder");
            providerBuilder.RaiseEvent(m => m.Arrived += null, argsToBeSent);
            _scenarioContext.Add("argsToBeSent", argsToBeSent);
        }

        [When(@"I simulate Data Arrived event")]
        public void WhenISimulateDataArrivedEvent()
        {
            var argsToBeSent = new DataEventArgs(new object());
            var providerBuilder = _scenarioContext.Get<EventProviderBuilder>("providerBuilder");
            providerBuilder.RaiseEvent(m => m.DataArrived += null, argsToBeSent);
            _scenarioContext.Add("argsToBeSent", argsToBeSent);
        }

        [When(@"I simulate Custom event")]
        public void WhenISimulateCustomEvent()
        {
            var argsToBeSent = new DataEventArgs(new object());
            var providerBuilder = _scenarioContext.Get<EventProviderBuilder>("providerBuilder");
            providerBuilder.RaiseEvent(m => m.CustomArrived += null, argsToBeSent);
            _scenarioContext.Add("argsToBeSent", argsToBeSent);
        }


        [Then(@"The event arguments should pass as expected")]
        public void ThenTheEventArgumentsShouldPassAsExpected()
        {
            var arrivedArgsRef = _scenarioContext.Get<WeakReference<EventArgs>>("arrivedArgsRef");
            arrivedArgsRef.TryGetTarget(out var arrivedArgs);
            var argsToBeSent = _scenarioContext.Get<EventArgs>("argsToBeSent");
            arrivedArgs.Should().BeSameAs(argsToBeSent);
        }

        [Then(@"The data event arguments should pass as expected")]
        public void ThenTheDataEventArgumentsShouldPassAsExpected()
        {
            var arrivedArgsRef = _scenarioContext.Get<WeakReference<DataEventArgs>>("arrivedArgsRef");
            arrivedArgsRef.TryGetTarget(out var arrivedArgs);
            var argsToBeSent = _scenarioContext.Get<DataEventArgs>("argsToBeSent");
            arrivedArgs.Should().BeSameAs(argsToBeSent);
        }

        [Then(@"The custom event arguments should pass as expected")]
        public void ThenTheCustomEventArgumentsShouldPassAsExpected()
        {
            var arrivedArgsRef = _scenarioContext.Get<WeakReference<DataEventArgs>>("arrivedArgsRef");
            arrivedArgsRef.TryGetTarget(out var arrivedArgs);
            var argsToBeSent = _scenarioContext.Get<DataEventArgs>("argsToBeSent");
            arrivedArgs.Should().BeSameAs(argsToBeSent);
        }

    }
}
