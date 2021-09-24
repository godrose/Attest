using Xunit;

namespace Attest.Fake.FakeItEasy.Tests
{
    public class SetupTests
    {
        [Fact(Skip = "Isn't implemented")]        
        public void WhenFakedObjectIsCalledOnce_ThenFakeSingleCallVerificationSucceeds()
        {
            var fakeFactory = new FakeFactory();
            var fake = fakeFactory.CreateFake<ILoginProvider>();

            var fakedObject = fake.Object;
            fakedObject.Login();

            fake.VerifyCall(t => t.Login());
        }
    }   
}
