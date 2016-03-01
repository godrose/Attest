using System.Threading.Tasks;

namespace Attest.Fake.Setup.Tests
{
    public interface ILoginProvider
    {
        bool IsLoggedIn { get; }

        Task Login();
        Task LoginWithOneParameter(string parameter);
        Task LoginWithTwoParameters(string firstParameter, string secondParameter);
    }
}