using System;

namespace Attest.Fake.Core
{
    public interface IFakeCallback
    {
        void Callback(Action action);
        void Callback<T>(Action<T> action);
        void Callback<T1, T2>(Action<T1, T2> action);
        void Callback<T1, T2, T3>(Action<T1, T2, T3> action);
        void Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);
        void Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);
    }
}