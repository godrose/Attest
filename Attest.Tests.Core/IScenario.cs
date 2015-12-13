namespace Attest.Tests.Core
{
    public interface IScenario
    {
        void Add(string key, object value);
        bool ContainsKey(string key);
        void Clear();
        object this[string key] { get; set; }        
    }
}
