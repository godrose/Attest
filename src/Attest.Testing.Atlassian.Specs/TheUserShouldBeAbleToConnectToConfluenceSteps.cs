namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class TheUserShouldBeAbleToConnectToConfluenceSteps
    {
        private int _pageId;
        private readonly WorkflowHelper _workflowHelper;
        private readonly ConfluenceContentsFactory _confluenceContentsFactory;
        private readonly ConfluenceStatusUpdater _confluenceStatusUpdater;
        private int _versionNumber;

        public TheUserShouldBeAbleToConnectToConfluenceSteps()
        {
            _workflowHelper = new WorkflowHelper();
            _confluenceContentsFactory = new ConfluenceContentsFactory(new FileSystemSpecsInfo());
            _confluenceStatusUpdater = new ConfluenceStatusUpdater(_confluenceContentsFactory, _workflowHelper);
        }

        [Given(@"There is a page which holds the current status content")]
        public void GivenThereIsAPageWhichHoldsTheCurrentStatusContent()
        {
            //for readability
            _pageId = 327681;
        }

        [When(@"I get the page")]
        public void WhenIGetThePage()
        {
            _versionNumber = _workflowHelper.SendContentGetRequest(_pageId);
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
