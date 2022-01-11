using System;
using System.Collections.Generic;

namespace Attest.Testing.Atlassian.Models
{
    public class StepResult
    {
        public string Duration { get; set; }
        public string Status { get; set; }
        public object Error { get; set; }
        public object Outputs { get; set; }
    }

    public class ExecutionResult
    {
        public string ContextType { get; set; }
        public string FeatureFolderPath { get; set; }
        public string FeatureTitle { get; set; }
        public string ScenarioTitle { get; set; }
        public List<object> ScenarioArguments { get; set; }
        public string Status { get; set; }
        public List<StepResult> StepResults { get; set; }
        public object Outputs { get; set; }
    }

    public class TestExecution
    {
        public List<object> Nodes { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime GenerationTime { get; set; }
        public string PluginUserSpecFlowId { get; set; }
        public object CLIUserSpecFlowId { get; set; }
        public List<ExecutionResult> ExecutionResults { get; set; }
        public object StepReports { get; set; }
    }
}
