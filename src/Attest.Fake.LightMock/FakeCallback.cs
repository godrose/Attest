using System;
using Attest.Fake.Core;
using LightMock;

namespace Attest.Fake.LightMock
{
    /// <summary>
    /// Implementation of fake callback without return value using LightMock framework
    /// </summary>
    /// <typeparam name="TFake">Type of faked service</typeparam>
    class LightFakeCallback<TFake> : IFakeCallback where TFake : class
    {
        private readonly Arrangement _fakeSetup;

        public LightFakeCallback(Arrangement fakeSetup)
        {
            _fakeSetup = fakeSetup;
        }

        public void Callback(Action action)
        {
            _fakeSetup.Callback(action);
        }

        public void Callback<T>(Action<T> action)
        {
            _fakeSetup.Callback(action);
        }

        public void Callback<T1, T2>(Action<T1, T2> action)
        {
            _fakeSetup.Callback(action);
        }

        public void Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            _fakeSetup.Callback(action);
        }

        public void Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            _fakeSetup.Callback(action);
        }

        public void Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            _fakeSetup.Callback(action);
        }
    }

    /// <summary>
    /// Implementation of fake callback with return value using Moq framework
    /// </summary>
    /// <typeparam name="TFake">Type of faked service</typeparam>
    /// <typeparam name="TResult">Type of return value</typeparam>
    class LightFakeCallbackWithResult<TFake, TResult> : IFakeCallbackWithResult<TResult> where TFake : class
    {
        private readonly Arrangement<TResult> _fakeSetup;        

        public LightFakeCallbackWithResult(Arrangement<TResult> fakeSetup)
        {
            _fakeSetup = fakeSetup;
        }

        public void Callback(Func<TResult> valueFunction)
        {
            _fakeSetup.Returns(valueFunction);
        }

        public void Callback<T>(Func<T, TResult> valueFunction)
        {
            _fakeSetup.Returns(valueFunction);
        }

        public void Callback<T1, T2>(Func<T1, T2, TResult> valueFunction)
        {
            _fakeSetup.Returns(valueFunction);
        }

        public void Callback<T1, T2, T3>(Func<T1, T2, T3, TResult> valueFunction)
        {
            _fakeSetup.Returns(valueFunction);
        }

        public void Callback<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TResult> valueFunction)
        {
            _fakeSetup.Returns(valueFunction);
        }

        public void Callback<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TResult> valueFunction)
        {
            throw new NotImplementedException("LightMock support up to 4 parameters in method with return values");
        }
    }
}