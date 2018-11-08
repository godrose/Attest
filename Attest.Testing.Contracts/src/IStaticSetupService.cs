using System.Collections.Generic;

namespace Attest.Testing.Contracts
{
    public interface IStaticSetupService
    {
        Dictionary<int, IStaticApplicationModule> OneTimeSetup();
    }
}
