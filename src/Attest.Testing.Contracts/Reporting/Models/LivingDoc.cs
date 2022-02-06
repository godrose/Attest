using System;
using System.Collections.Generic;

namespace Attest.Testing.Reporting.Models
{
    /// <summary>
    /// Represents the living doc tool information
    /// </summary>
    public class Versions
    {
        /// <summary>
        /// Gets or sets the build tool version.
        /// </summary>
        public string BuildToolVersion { get; set; }
        /// <summary>
        /// Gets or sets the JSON schema version.
        /// </summary>
        public string JSONSchemaVersion { get; set; }
    }

    /// <summary>
    /// The header.
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Gets or sets the collection of cells.
        /// </summary>
        public List<object> Cells { get; set; }
    }

    /// <summary>
    /// The table row.
    /// </summary>
    public class TableRow
    {
        /// <summary>
        /// Gets or sets the collection of cells.
        /// </summary>
        public List<string> Cells { get; set; }
    }

    /// <summary>
    /// The data table.
    /// </summary>
    public class DataTable
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public Header Header { get; set; }
        /// <summary>
        /// Gets or sets the collection of table rows.
        /// </summary>
        public List<TableRow> TableRows { get; set; }
    }

    /// <summary>
    /// The step.
    /// </summary>
    public class Step
    {
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Gets or sets the step keyword.
        /// </summary>
        public string StepKeyword { get; set; }
        /// <summary>
        /// Gets or sets the Gherkin keyword.
        /// </summary>
        public string GherkinKeyword { get; set; }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the multi-line string.
        /// </summary>
        public object MultiLineString { get; set; }
        /// <summary>
        /// Gets or sets the data table.
        /// </summary>
        public DataTable DataTable { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
    }

    /// <summary>
    /// The table.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public Header Header { get; set; }

        /// <summary>
        /// Gets or sets the table rows.
        /// </summary>
        public List<TableRow> TableRows { get; set; }
    }

    /// <summary>
    /// The example.
    /// </summary>
    public class Example
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public object Name { get; set; }
        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        public Table Table { get; set; }
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public object Description { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public List<object> Tags { get; set; }
        /// <summary>
        /// Gets or sets the title hash.
        /// </summary>
        public string TitleHash { get; set; }
    }

    /// <summary>
    /// The scenario definition.
    /// </summary>
    public class ScenarioDefinition
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        public List<Step> Steps { get; set; }
        /// <summary>
        /// Gets or sets the examples.
        /// </summary>
        public List<Example> Examples { get; set; }
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public object Description { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Gets or sets the title hash.
        /// </summary>
        public string TitleHash { get; set; }
    }

    /// <summary>
    /// The background
    /// </summary>
    public class Background
    {
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        public object Keyword { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public object Description { get; set; }
        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        public List<object> Steps { get; set; }
    }

    /// <summary>
    /// The feature.
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the scenario definitions.
        /// </summary>
        public List<ScenarioDefinition> ScenarioDefinitions { get; set; }
        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        public Background Background { get; set; }
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        public object FilePath { get; set; }
        /// <summary>
        /// Gets or sets the repository path.
        /// </summary>
        public object RepositoryPath { get; set; }
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public List<string> Tags { get; set; }
        /// <summary>
        /// Gets or sets the title hash.
        /// </summary>
        public string TitleHash { get; set; }
    }

    /// <summary>
    /// The folder.
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the folders.
        /// </summary>
        public List<Folder> Folders { get; set; }
        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public List<Feature> Features { get; set; }
        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string NodeType { get; set; }
    }

    /// <summary>
    /// The node.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the versions.
        /// </summary>
        public Versions Versions { get; set; }
        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        public object Prefix { get; set; }
        /// <summary>
        /// Gets or sets the work item url template.
        /// </summary>
        public object WorkItemUrlTemplate { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the folders.
        /// </summary>
        public List<Folder> Folders { get; set; }
        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        public List<object> Features { get; set; }
    }

    /// <summary>
    /// The unused step definition.
    /// </summary>
    public class UnusedStepDefinition
    {
        /// <summary>
        /// Gets or sets the class name.
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the method name.
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// Gets or sets the fully qualified name.
        /// </summary>
        public string FullyQualifiedName { get; set; }
        /// <summary>
        /// Gets or sets the regex.
        /// </summary>
        public string Regex { get; set; }
        /// <summary>
        /// Gets or sets the step definition attribute name.
        /// </summary>
        public string StepDefinitionAttributeName { get; set; }
        /// <summary>
        /// Gets or sets the step definition types.
        /// </summary>
        public List<string> StepDefinitionTypes { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public List<object> Parameters { get; set; }
    }

    /// <summary>
    /// The unused step definition report.
    /// </summary>
    public class UnusedStepDefinitionReport
    {
        /// <summary>
        /// Gets or sets the step definition discovery result.
        /// </summary>
        public string StepDefinitionDiscoveryResult { get; set; }
        /// <summary>
        /// Gets or sets the unused step definitions.
        /// </summary>
        public List<UnusedStepDefinition> UnusedStepDefinitions { get; set; }
    }

    /// <summary>
    /// The step reports.
    /// </summary>
    public class StepReports
    {
        /// <summary>
        /// Gets or sets the unused step definition report.
        /// </summary>
        public UnusedStepDefinitionReport UnusedStepDefinitionReport { get; set; }
    }

    /// <summary>
    /// The feature data.
    /// </summary>
    public class FeatureData
    {
        /// <summary>
        /// Gets or sets the collection of nodes.
        /// </summary>
        public List<Node> Nodes { get; set; }
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
        public object PluginUserSpecFlowId { get; set; }
        /// <summary>
        /// Gets or sets the cli user id.
        /// </summary>
        public object CLIUserSpecFlowId { get; set; }
        /// <summary>
        /// Gets or sets the collection of the execution results.
        /// </summary>
        public List<object> ExecutionResults { get; set; }
        /// <summary>
        /// Gets or sets the step reports.
        /// </summary>
        public StepReports StepReports { get; set; }
    }
}
