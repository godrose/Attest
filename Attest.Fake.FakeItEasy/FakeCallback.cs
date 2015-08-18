using System;
using Attest.Fake.Core;
using FakeItEasy;
using FakeItEasy.Configuration;

namespace Attest.Fake.FakeItEasy
{
    class EasyFakeCallback<TFaked> : IFakeCallback
    {
        private readonly IAnyCallConfigurationWithNoReturnTypeSpecified _callConfiguration;

        public EasyFakeCallback(IAnyCallConfigurationWithNoReturnTypeSpecified callConfiguration)
        {
            _callConfiguration = callConfiguration;
        }

        public void Callback(Action action)
        {
            _callConfiguration.Invokes(action);
        }

        public void Callback<T>(Action<T> action)
        {
            _callConfiguration.Invokes(action);
        }

        public void Callback<T1, T2>(Action<T1, T2> action)
        {
            _callConfiguration.Invokes(action);
        }

        public void Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            _callConfiguration.Invokes(action);
        }

        public void Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            _callConfiguration.Invokes(action);
        }

        public void Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            throw new NotSupportedException("FakeItEasy provides support up for 4 parameters");
        }
    }

    class EasyFakeCallbackWithResult<TFaked, TResult> : IFakeCallbackWithResult<TResult>
    {
        private readonly IAnyCallConfigurationWithReturnTypeSpecified<TResult> _callConfiguration;

        public EasyFakeCallbackWithResult(IAnyCallConfigurationWithReturnTypeSpecified<TResult> callConfiguration)
        {
            _callConfiguration = callConfiguration;
        }

        public void Callback(Func<TResult> func)
        {
            _callConfiguration.ReturnsLazily(func);
        }
    }
}
