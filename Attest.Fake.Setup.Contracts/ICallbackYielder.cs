namespace Attest.Fake.Setup.Contracts
{
    public interface ICallbackYielder<out TCallback>
    {
        TCallback YieldCallback();
    }
}