using Attest.Testing.Context.SpecFlow;
using TechTalk.SpecFlow;

namespace Attest.Testing.SpecFlow.Specs
{
    internal sealed class FeatureDataStoreDataStore : FeatureDataStoreBase
    {
        public FeatureDataStoreDataStore(FeatureContext featureContext) : base(featureContext)
        {
        }

        public string Data
        {
            get => GetValue<string>();
            set
            {
                SetValue(value);
                NumberOfSetCalls++;
            }
        }

        public int NumberOfSetCalls
        {
            get => GetValue<int>();
            private set => SetValue(value);
        }
    }
}
