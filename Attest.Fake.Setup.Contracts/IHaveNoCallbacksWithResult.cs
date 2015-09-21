namespace Attest.Fake.Setup.Contracts
{
    public interface IHaveNoCallbacksWithResult<TCallback, in TResult> : IAddCallbackWithResult<TCallback, TResult>
    {

    }
}