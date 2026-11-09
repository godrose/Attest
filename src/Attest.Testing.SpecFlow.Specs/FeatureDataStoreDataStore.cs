#if REQNROLL
using Attest.Testing.Context.Reqnroll;
#else
using Attest.Testing.Context.SpecFlow;
#endif
#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

#if REQNROLL
namespace Attest.Testing.Reqnroll.Specs
#else
namespace Attest.Testing.SpecFlow.Specs
#endif
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
