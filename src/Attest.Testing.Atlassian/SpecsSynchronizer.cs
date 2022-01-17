namespace Attest.Testing.Atlassian
{
    public class SpecsSynchronizer
    {
        private readonly JiraProvider _jiraProvider;

        public SpecsSynchronizer(JiraProvider jiraProvider)
        {
            _jiraProvider = jiraProvider;
        }

        public void SyncDescription(int issueId)
        {
            var raw = _jiraProvider.GetIssueRaw(issueId);
            _jiraProvider.UpdateIssueDescription(issueId, raw);
        }
    }
}
