using System;

namespace Attest.Fake.Core
{
    public interface IFakeCallbackWithResult<in TResult>
    {
        void Callback(Func<TResult> func);
        void Callback<T>(Func<T, TResult> valueFunction);
        void Callback<T1, T2>(Func<T1, T2, TResult> valueFunction);
        void Callback<T1, T2, T3>(Func<T1, T2, T3, TResult> valueFunction);
        void Callback<T1, T2, T3, T4>(Func<T1, T2, T3, T4, TResult> valueFunction);
        void Callback<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, TResult> valueFunction);
    }
}