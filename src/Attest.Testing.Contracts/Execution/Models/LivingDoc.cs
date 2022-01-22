using System;
using System.Collections.Generic;

namespace Attest.Testing.Execution.Models
{
    public class Versions
    {
        public string BuildToolVersion { get; set; }
        public string JSONSchemaVersion { get; set; }
    }

    public class Header
    {
        public List<object> Cells { get; set; }
    }

    public class TableRow
    {
        public List<string> Cells { get; set; }
    }

    public class DataTable
    {
        public Header Header { get; set; }
        public List<TableRow> TableRows { get; set; }
    }

    public class Step
    {
        public string Keyword { get; set; }
        public string StepKeyword { get; set; }
        public string GherkinKeyword { get; set; }
        public string Text { get; set; }
        public object MultiLineString { get; set; }
        public DataTable DataTable { get; set; }
        public string NodeType { get; set; }
    }

    public class Table
    {
        public Header Header { get; set; }
        public List<TableRow> TableRows { get; set; }
    }

    public class Example
    {
        public object Name { get; set; }
        public Table Table { get; set; }
        public string Keyword { get; set; }
        public string NodeType { get; set; }
        public string Title { get; set; }
        public object Description { get; set; }
        public List<object> Tags { get; set; }
        public string TitleHash { get; set; }
    }

    public class ScenarioDefinition
    {
        public string Id { get; set; }
        public List<Step> Steps { get; set; }
        public List<Example> Examples { get; set; }
        public string Keyword { get; set; }
        public string NodeType { get; set; }
        public string Title { get; set; }
        public object Description { get; set; }
        public List<string> Tags { get; set; }
        public string TitleHash { get; set; }
    }

    public class BackGround
    {
        public object Keyword { get; set; }
        public string NodeType { get; set; }
        public object Description { get; set; }
        public List<object> Steps { get; set; }
    }

    public class Feature
    {
        public string Id { get; set; }
        public List<ScenarioDefinition> ScenarioDefinitions { get; set; }
        public BackGround BackGround { get; set; }
        public object FilePath { get; set; }
        public object RepositoryPath { get; set; }
        public string FileName { get; set; }
        public string Keyword { get; set; }
        public string NodeType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public string TitleHash { get; set; }
    }

    public class Folder
    {
        public string Title { get; set; }
        public List<Folder> Folders { get; set; }
        public List<Feature> Features { get; set; }
        public string NodeType { get; set; }
    }

    public class Node
    {
        public Versions Versions { get; set; }
        public object Prefix { get; set; }
        public object WorkItemUrlTemplate { get; set; }
        public string Title { get; set; }
        public List<Folder> Folders { get; set; }
        public List<object> Features { get; set; }
    }

    public class UnusedStepDefinition
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string FullyQualifiedName { get; set; }
        public string Regex { get; set; }
        public string StepDefinitionAttributeName { get; set; }
        public List<string> StepDefinitionTypes { get; set; }
        public List<object> Parameters { get; set; }
    }

    public class UnusedStepDefinitionReport
    {
        public string StepDefinitionDiscoveryResult { get; set; }
        public List<UnusedStepDefinition> UnusedStepDefinitions { get; set; }
    }

    public class StepReports
    {
        public UnusedStepDefinitionReport UnusedStepDefinitionReport { get; set; }
    }

    public class FeatureData
    {
        public List<Node> Nodes { get; set; }
        public DateTime ExecutionTime { get; set; }
        public DateTime GenerationTime { get; set; }
        public object PluginUserSpecFlowId { get; set; }
        public object CLIUserSpecFlowId { get; set; }
        public List<object> ExecutionResults { get; set; }
        public StepReports StepReports { get; set; }
    }
}
