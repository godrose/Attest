using System;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Attest.Fake.Moq.Specs
{
    [Binding]
    internal sealed class EventInvocationSteps
    {
        private readonly EventInvocationScenarioDataStore _scenarioDataStore;

        public EventInvocationSteps(ScenarioContext scenarioContext)
        {
            _scenarioDataStore = new EventInvocationScenarioDataStore(scenarioContext);
        }

        [Given(@"The Arrived event is to be tested")]
        public void GivenTheArrivedEventIsToBeTested()
        {
            SetupEventToBeTested<EventArgs>((provider, reference) =>
                provider.Arrived += (sender, args) => reference.SetTarget(args));
        }

        [Given(@"The Data Arrived event is to be tested")]
        public void GivenTheDataArrivedEventIsToBeTested()
        {
            SetupEventToBeTested<DataEventArgs>((provider, reference) =>
                provider.DataArrived += (sender, args) => reference.SetTarget(args));
        }

        [Given(@"The Custom event is to be tested")]
        public void GivenTheCustomEventIsToBeTested()
        {
            SetupEventToBeTested<DataEventArgs>((provider, reference) =>
                provider.CustomArrived += (sender, args) => reference.SetTarget(args));
        }

        private void SetupEventToBeTested<TEventArgs>(Action<IEventProvider, WeakReference<TEventArgs>> eventSubscription) where TEventArgs : class
        {
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var instance = eventProviderBuilder.Object;
            var arrivedArgs = new WeakReference<TEventArgs>(null);
            eventSubscription(instance, arrivedArgs);
            _scenarioDataStore.ProviderBuilder = eventProviderBuilder;
            _scenarioDataStore.ArrivedArgsRef = arrivedArgs;
        }

        [When(@"I simulate Arrived event")]
        public void WhenISimulateArrivedEvent()
        {
            SimulateEvent(() => new EventArgs(),
                (providerBuilder, argsToBeSent) =>
                    providerBuilder.RaiseEvent(m => m.Arrived += null, argsToBeSent));
        }

        [When(@"I simulate Data Arrived event")]
        public void WhenISimulateDataArrivedEvent()
        {
            SimulateEvent(() => new DataEventArgs(new object()),
                (providerBuilder, argsToBeSent) =>
                    providerBuilder.RaiseEvent(m => m.DataArrived += null, argsToBeSent));
        }

        [When(@"I simulate Custom event")]
        public void WhenISimulateCustomEvent()
        {
            SimulateEvent(() => new DataEventArgs(new object()),
                (providerBuilder, argsToBeSent) =>
                    providerBuilder.RaiseEvent(m => m.CustomArrived += null, argsToBeSent));
        }

        private void SimulateEvent<TEventArgs>(Func<TEventArgs> eventFactory, Action<EventProviderBuilder, TEventArgs> eventInvocation)
        {
            var argsToBeSent = eventFactory();
            var providerBuilder = _scenarioDataStore.ProviderBuilder;
            eventInvocation(providerBuilder, argsToBeSent);
            _scenarioDataStore.ArgsToBeSent = argsToBeSent;
        }

        [Then(@"The event arguments should pass as expected")]
        public void ThenTheEventArgumentsShouldPassAsExpected()
        {
            AssertEventArguments<EventArgs>();
        }

        [Then(@"The data event arguments should pass as expected")]
        public void ThenTheDataEventArgumentsShouldPassAsExpected()
        {
            AssertEventArguments<DataEventArgs>();
        }

        [Then(@"The custom event arguments should pass as expected")]
        public void ThenTheCustomEventArgumentsShouldPassAsExpected()
        {
            AssertEventArguments<DataEventArgs>();
        }

        private void AssertEventArguments<TEventArgs>() where TEventArgs : class
        {
            var arrivedArgsRef = _scenarioDataStore.ArrivedArgsRef as WeakReference<TEventArgs>;
            arrivedArgsRef.TryGetTarget(out var arrivedArgs);
            var argsToBeSent = _scenarioDataStore.ArgsToBeSent;
            arrivedArgs.Should().BeSameAs(argsToBeSent);
        }
    }
}
