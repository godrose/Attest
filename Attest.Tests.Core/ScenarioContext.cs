namespace Attest.Tests.Core
{
    public static class ScenarioContext
    {
        private static IScenario _current;

        public static IScenario Current
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;                
            }
        }
    }
}
