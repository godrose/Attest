using Microsoft.Extensions.Configuration;

namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class TheUserShouldBeAbleToConnectToConfluenceSteps
    {
        private int _pageId;
        private readonly ConfluenceProvider _confluenceProvider;
        private readonly ConfluenceStatusUpdater _confluenceStatusUpdater;
        private readonly IConfiguration _configuration;
        private int _versionNumber;

        public TheUserShouldBeAbleToConnectToConfluenceSteps(
            ConfluenceProvider confluenceProvider,
            ConfluenceStatusUpdater confluenceStatusUpdater,
            IConfiguration configuration)
        {
            _confluenceProvider = confluenceProvider;
            _confluenceStatusUpdater = confluenceStatusUpdater;
            _configuration = configuration;
        }

        [Given(@"There is a page which holds the current status content")]
        public void GivenThereIsAPageWhichHoldsTheCurrentStatusContent()
        {
            //for readability
            _pageId = int.Parse(_configuration.GetSection("Atlassian").GetSection("Confluence").GetSection("StatusPageId").Value);
        }

        [When(@"I get the page")]
        public void WhenIGetThePage()
        {
            _versionNumber = _confluenceProvider.GetNewPageVersion(_pageId);
        }

        [When(@"I update the current status")]
        public void WhenIUpdateTheCurrentStatus()
        {
            _confluenceStatusUpdater.UpdateFromReport(_pageId);
        }

        [Then(@"I am able to see the version number")]
        public void ThenIAmAbleToSeeTheVersionNumber()
        {
            _versionNumber.Should().BeGreaterThan(0);
        }

        [Then(@"The status is updated")]
        public void ThenTheStatusIsUpdated()
        {
            //TODO: Add implementation
        }
    }
}
