using System;
using Newtonsoft.Json;

namespace Attest.Testing.Atlassian.Models
{
    internal class Expandable
    {
        [JsonProperty("settings")]
        public string Settings { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("operations")]
        public string Operations { get; set; }

        [JsonProperty("lookAndFeel")]
        public string LookAndFeel { get; set; }

        [JsonProperty("identifiers")]
        public string Identifiers { get; set; }

        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("history")]
        public string History { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("personalSpace")]
        public string PersonalSpace { get; set; }

        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty("previousVersion")]
        public string PreviousVersion { get; set; }

        [JsonProperty("contributors")]
        public string Contributors { get; set; }

        [JsonProperty("nextVersion")]
        public string NextVersion { get; set; }

        [JsonProperty("collaborators")]
        public string Collaborators { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("childTypes")]
        public string ChildTypes { get; set; }

        [JsonProperty("container")]
        public string Container { get; set; }

        [JsonProperty("schedulePublishDate")]
        public string SchedulePublishDate { get; set; }

        [JsonProperty("children")]
        public string Children { get; set; }

        [JsonProperty("restrictions")]
        public string Restrictions { get; set; }

        [JsonProperty("ancestors")]
        public string Ancestors { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("descendants")]
        public string Descendants { get; set; }
    }

    public class Links
    {
        [JsonProperty("webui")]
        public string Webui { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("editui")]
        public string Editui { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("tinyui")]
        public string Tinyui { get; set; }

        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }

    internal class Space
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public class ProfilePicture
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
    }

    internal class CreatedBy
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("publicName")]
        public string PublicName { get; set; }

        [JsonProperty("profilePicture")]
        public ProfilePicture ProfilePicture { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("isExternalCollaborator")]
        public bool IsExternalCollaborator { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    internal class History
    {
        [JsonProperty("latest")]
        public bool Latest { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    internal class By
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("publicName")]
        public string PublicName { get; set; }

        [JsonProperty("profilePicture")]
        public ProfilePicture ProfilePicture { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("isExternalCollaborator")]
        public bool IsExternalCollaborator { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    internal class Version
    {
        [JsonProperty("by")]
        public By By { get; set; }

        [JsonProperty("when")]
        public DateTime When { get; set; }

        [JsonProperty("friendlyWhen")]
        public string FriendlyWhen { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("minorEdit")]
        public bool MinorEdit { get; set; }

        [JsonProperty("syncRev")]
        public string SyncRev { get; set; }

        [JsonProperty("syncRevSource")]
        public string SyncRevSource { get; set; }

        [JsonProperty("confRev")]
        public string ConfRev { get; set; }

        [JsonProperty("contentTypeModified")]
        public bool ContentTypeModified { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

    public class MacroRenderedOutput
    {
    }

    public class Extensions
    {
        [JsonProperty("position")]
        public int Position { get; set; }
    }

    internal class ConfluenceContentResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("space")]
        public Space Space { get; set; }

        [JsonProperty("history")]
        public History History { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("macroRenderedOutput")]
        public MacroRenderedOutput MacroRenderedOutput { get; set; }

        [JsonProperty("extensions")]
        public Extensions Extensions { get; set; }

        [JsonProperty("_expandable")]
        public Expandable Expandable { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }

}
