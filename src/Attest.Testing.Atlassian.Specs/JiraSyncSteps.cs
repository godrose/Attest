namespace Attest.Testing.Atlassian.Specs
{
    [Binding]
    public class JiraSyncSteps
    {
        private readonly JiraProvider _jiraProvider;
        private int _issueId;

        public JiraSyncSteps(JiraProvider jiraProvider)
        {
            _jiraProvider = jiraProvider;
        }

        [Given(@"There is an issue with id (.*) with specs section")]
        public void GivenThereIsAnIssueWithSpecsSection(int issueId)
        {
            _issueId = issueId;
        }

        [When(@"I update the user story description from the correspondent feature files")]
        public void WhenIUpdateTheUserStoryDescriptionFromTheCorrespondentFeatureFiles()
        {
            var specsSynchronizer = new SpecsSynchronizer(_jiraProvider);
            specsSynchronizer.SyncDescriptionFromFilesToJira(_issueId);
        }

        [Then(@"The user story description is updated")]
        public void ThenTheUserStoryDescriptionIsUpdated()
        {
            var expectedDescription = @"Feature: The user should be able to connect to Jira

In order to see clearer picture
As a stakeholder
I would like an option to filter issues easily

Scenario: The user should be able to find out whether ticket belongs to the current sprint

Given There is an Atlassian account
And There is a ticket with id 1 which belongs to the current sprint
When The user wants to find out whether this ticket belongs to the current sprint
Then The result is positive

Feature: The user should be able to connect to Confluence

In order to see the last project status
As a stakeholder
I would like the system to update the status automtically based on automated execution report

Scenario: The user should be able to get a Confluence page version

Given There is an Atlassian account
And There is a page which holds the current status content
When I get the page
Then I am able to see the version number

Scenario: The user should be able to update current status

Given There is an Atlassian account
And There is a page which holds the current status content
When I update the current status
Then The status is updated";
            var description = _jiraProvider.GetIssueSpecsSection(_issueId);
            description.Should().Be(expectedDescription);
        }
    }
}