namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class TheUserShouldBeAbleToConnectToJIRASteps
    {
        private WorkflowHelper _workflowHelper;
        private int _ticketId;
        private bool _result;
        private const string Prefix = "BDD";

        public TheUserShouldBeAbleToConnectToJIRASteps()
        {
            _workflowHelper = new WorkflowHelper();
        }

        [Given(@"There is an account in JIRA")]
        public void GivenThereIsAnAccountInJIRA()
        {
           //for readability
        }

        [Given(@"There is a ticket with id (.*) which belongs to the current sprint")]
        public void GivenThereIsATicketWithIdWhichBelongsToTheCurrentSprint(int ticketId)
        {
            _ticketId = ticketId;
        }

        [When(@"The user wants to find out whether this ticket belongs to the current sprint")]
        public void WhenTheUserWantsToFindOutWhetherThisTicketBelongsToTheCurrentSprint()
        {
            _result = _workflowHelper.IsCurrentSprint(_ticketId);
        }

        [Then(@"The result is positive")]
        public void ThenTheResultIsPositive()
        {
            _result.Should().BeTrue();
        }
    }
}
