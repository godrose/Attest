namespace Attest.Fake.Setup.Contracts
{
    public interface IReturnResult<out TResult>
    {
        TResult Result { get; }
    }
}