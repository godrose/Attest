// ReSharper disable once CheckNamespace
namespace Attest.Testing.Configuration
{
    public abstract class RunGuardInfoBase : IRunGuardInfo
    {
        protected RunGuardInfoBase(string key)
        {
            Key = key;
        }

        public string Key { get; }
        protected abstract object TruthyValue { get; }
        protected abstract object ParseValue(string input);

        public bool CanRun(string input)
        {
            var parsedValue = ParseValue(input);
            return TruthyValue == null ? 
                parsedValue == null : 
                parsedValue != null && parsedValue.Equals(TruthyValue);
        }
    }
}