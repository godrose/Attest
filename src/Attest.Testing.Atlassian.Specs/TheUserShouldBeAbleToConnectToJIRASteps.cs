namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class TheUserShouldBeAbleToConnectToJiraSteps
    {
        private readonly WorkflowHelper _workflowHelper;
        private int _ticketId;
        private bool _result;

        public TheUserShouldBeAbleToConnectToJiraSteps(WorkflowHelper workflowHelper)
        {
            _workflowHelper = workflowHelper;
        }

        [Given(@"There is an account in Jira")]
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
            _result = _workflowHelper.IsIssueIncludedInTheCurrentSprint(_ticketId);
        }

        [Then(@"The result is positive")]
        public void ThenTheResultIsPositive()
        {
            _result.Should().BeTrue();
        }
    }
}
