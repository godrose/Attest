namespace Attest.Testing.Configuration
{
    public interface IRunGuardInfo
    {
        string Key { get; }
        bool CanRun(string input);
    }
}
