using System;
using System.Collections.Generic;

namespace Attest.Testing.Reporting.Models
{
    /// <summary>
    /// The step result.
    /// </summary>
    public class StepResult
    {
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        public object Error { get; set; }
        /// <summary>
        /// Gets or sets the outputs.
        /// </summary>
        public object Outputs { get; set; }
    }

    /// <summary>
    /// The execution result.
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        /// Gets or sets the context type.
        /// </summary>
        public string ContextType { get; set; }
        /// <summary>
        /// Gets or sets the feature folder path.
        /// </summary>
        public string FeatureFolderPath { get; set; }
        /// <summary>
        /// Gets or sets the feature title.
        /// </summary>
        public string FeatureTitle { get; set; }
        /// <summary>
        /// Gets or sets the scenario title.
        /// </summary>
        public string ScenarioTitle { get; set; }
        /// <summary>
        /// Gets or sets the scenario arguments.
        /// </summary>
        public List<object> ScenarioArguments { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the step results.
        /// </summary>
        public List<StepResult> StepResults { get; set; }
        /// <summary>
        /// Gets or sets the outputs.
        /// </summary>
        public object Outputs { get; set; }
    }

    /// <summary>
    /// The test execution.
    /// </summary>
    public class TestExecution
    {
        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        public List<object> Nodes { get; set; }
        /// <summary>
        /// Gets or sets the execution time.
        /// </summary>
        public DateTime ExecutionTime { get; set; }
        /// <summary>
        /// Gets or sets the generation time.
        /// </summary>
        public DateTime GenerationTime { get; set; }
        /// <summary>
        /// Gets or sets the plugin user id.
        /// </summary>
        public string PluginUserSpecFlowId { get; set; }
        /// <summary>
        /// Gets or sets the cli user id.
        /// </summary>
        public object CLIUserSpecFlowId { get; set; }
        /// <summary>
        /// Gets or sets the execution results.
        /// </summary>
        public List<ExecutionResult> ExecutionResults { get; set; }
        /// <summary>
        /// Gets or sets the step reports.
        /// </summary>
        public object StepReports { get; set; }
    }
}
