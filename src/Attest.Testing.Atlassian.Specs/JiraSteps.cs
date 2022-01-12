namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class JiraSteps
    {
        private readonly JiraProvider _jiraProvider;
        private int _ticketId;
        private bool _result;

        public JiraSteps(JiraProvider jiraProvider)
        {
            _jiraProvider = jiraProvider;
        }

        [Given(@"There is a ticket with id (.*) which belongs to the current sprint")]
        public void GivenThereIsATicketWithIdWhichBelongsToTheCurrentSprint(int ticketId)
        {
            _ticketId = ticketId;
        }

        [When(@"The user wants to find out whether this ticket belongs to the current sprint")]
        public void WhenTheUserWantsToFindOutWhetherThisTicketBelongsToTheCurrentSprint()
        {
            _result = _jiraProvider.IsIssueIncludedInTheCurrentSprint(_ticketId);
        }

        [Then(@"The result is positive")]
        public void ThenTheResultIsPositive()
        {
            _result.Should().BeTrue();
        }
    }
}
