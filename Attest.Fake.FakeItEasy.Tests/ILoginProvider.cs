using System.Threading.Tasks;

namespace Attest.Fake.FakeItEasy.Tests
{
    public interface ILoginProvider
    {
        bool IsLoggedIn { get; }

        Task Login();
        Task LoginWithOneParameter(string parameter);
        Task LoginWithTwoParameters(string firstParameter, string secondParameter);
        Task LoginWithThreeParameters(string firstParameter, string secondParameter, string thirdParameter);

        Task LoginWithFourParameters(string firstParameter, string secondParameter, string thirdParameter,
            string fourthParameter);

        Task LoginWithFiveParameters(string firstParameter, string secondParameter, string thirdParameter,
            string fourthParameter, string fifthParameter);
    }
}