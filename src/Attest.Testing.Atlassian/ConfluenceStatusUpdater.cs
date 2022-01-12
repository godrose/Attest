using System.Linq;

namespace Attest.Testing.Atlassian
{
    public class ConfluenceStatusUpdater
    {
        private readonly ConfluenceContentsFactory _confluenceContentsFactory;
        private readonly WorkflowHelper _workflowHelper;

        public ConfluenceStatusUpdater(
            ConfluenceContentsFactory confluenceContentsFactory,
            WorkflowHelper workflowHelper)
        {
            _confluenceContentsFactory = confluenceContentsFactory;
            _workflowHelper = workflowHelper;
        }

        public void UpdateFromReport(int pageId)
        {
            var contents = _confluenceContentsFactory.BuildContents(
                    pageId,
                    null)
                .ToArray();

            foreach (var content in contents)
            {
                _workflowHelper.UpdatePage(pageId, content);
            }
        }
    }
}
