using System.Threading.Tasks;

namespace Attest.Fake.Setup.Tests
{
    public interface ILoginProvider
    {
        Task Login();
    }
}