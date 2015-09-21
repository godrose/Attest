namespace Attest.Fake.Setup.Contracts
{
    public interface IHaveNoCallbacksWithResult<TCallback, in TResult> : IAddCallbackWithResult<TCallback, TResult>
    {

    }

    public interface IHaveNoCallbacksWithResult<TCallback, T, in TResult> : IAddCallbackWithResult<TCallback, T, TResult>
    {
    }

    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, TResult>
    {
    }

    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, TResult>
    {
    }

    public interface IHaveNoCallbacksWithResult<TCallback, T1,T2, T3, T4, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, T4, TResult>
    {
    }

    public interface IHaveNoCallbacksWithResult<TCallback, T1, T2, T3, T4, T5, in TResult> : IAddCallbackWithResult<TCallback, T1, T2, T3, T4, T5, TResult>
    {
    }
}