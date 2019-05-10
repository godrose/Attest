using Attest.Fake.Core;
using FluentAssertions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace Attest.Fake.Moq.Tests
{
    public class PerformanceTests
    {
        static PerformanceTests()
        {
            FakeFactoryContext.Current = new FakeFactory();
            ConstraintFactoryContext.Current = new ConstraintFactory();
        }

        [Fact]
        public async void RaiseNumerousTimes_PerformanceDifferenceIsNegligible()
        {
            var numberOfTimes = 1000;
            TimeSpan interval = TimeSpan.FromMilliseconds(20);
            var sw = new Stopwatch();
            var eventProviderBuilder = EventProviderBuilder.CreateBuilder();
            var fakeEventProvider = new FakeEventProvider();
            var instance = eventProviderBuilder.Object;
            DataEventArgs arrivedArgs = null;
            instance.DataArrived += (sender, args) => arrivedArgs = args;
            fakeEventProvider.DataArrived += (sender, args) => arrivedArgs = args;

            sw.Start();
            for (int i = 0; i < numberOfTimes; i++)
            {
                var argsTobeSent = new DataEventArgs(new object());
                eventProviderBuilder.RaiseDataEvent(m => m.DataArrived += null, argsTobeSent);
                await Task.Delay(interval);
            }
            sw.Stop();
            var builderElapsed = sw.Elapsed;
           
            sw.Restart();
            for (int i = 0; i < numberOfTimes; i++)
            {
                var argsTobeSent = new DataEventArgs(new object());
                fakeEventProvider.RaiseDataArrived(argsTobeSent);
                await Task.Delay(interval);
            }
            sw.Stop();
            var fakeElapsed = sw.Elapsed;

            builderElapsed.Should().BeCloseTo(fakeElapsed, precision: 20);
        }
    }
}
