using System;
using Attest.Fake.Core;
using Moq.Language.Flow;

namespace Attest.Fake.Moq
{
    class MoqFakeCallback<TFake> : IFakeCallback where TFake : class
    {
        private readonly ISetup<TFake> _fakeSetup;

        public MoqFakeCallback(ISetup<TFake> fakeSetup)
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

    class MoqFakeCallbackWithResult<TFake, TResult> : IFakeCallbackWithResult<TResult> where TFake : class
    {
        private readonly ISetup<TFake, TResult> _fakeSetup;

        public MoqFakeCallbackWithResult(ISetup<TFake, TResult> fakeSetup)
        {
            _fakeSetup = fakeSetup;
        }

        public void Callback(Func<TResult> func)
        {
            _fakeSetup.Returns(func);
        }
    }
}
