using System.Linq;

namespace Attest.Testing.Atlassian
{
    public sealed class ConfluenceStatusUpdater
    {
        private readonly ConfluenceContentsFactory _confluenceContentsFactory;
        private readonly ConfluenceProvider _confluenceProvider;

        public ConfluenceStatusUpdater(
            ConfluenceContentsFactory confluenceContentsFactory,
            ConfluenceProvider confluenceProvider)
        {
            _confluenceContentsFactory = confluenceContentsFactory;
            _confluenceProvider = confluenceProvider;
        }

        public void UpdateFromReport(int pageId)
        {
            var contents = _confluenceContentsFactory.BuildContents(
                    pageId,
                    null)
                .ToArray();

            foreach (var content in contents)
            {
                _confluenceProvider.UpdatePage(pageId, content);
            }
        }
    }
}
