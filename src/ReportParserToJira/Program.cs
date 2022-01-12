﻿using System.Linq;
using Attest.Testing.Atlassian;
using Attest.Testing.Execution;

namespace ReportParserToJira
{
    class Program
    {
        static void Main(string[] args)
        {
            var workflowHelper = new WorkflowHelper();
            int pageId = 327681;
            var confluenceContentsFactory = new ConfluenceContentsFactory(new FileSystemSpecsInfo());
            var contents = confluenceContentsFactory.BuildContents(
                pageId,
                args.FirstOrDefault())
                .ToArray();

            foreach (var content in contents)
            {
                workflowHelper.UpdatePage(pageId, content);
            }
        }
    }
}
