using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Attest.Fake.Data.Shared
{
    /// <summary>
    /// Converts builders collection to and from text. 
    /// </summary>
    public interface IBuildersCollectionConverter
    {
        /// <summary>
        /// Converts builders collection to text.
        /// </summary>
        /// <param name="buildersCollection"></param>
        /// <returns></returns>
        string Serialize(BuildersCollection buildersCollection);

        /// <summary>
        /// Converts the specified text to builders collection.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        BuildersCollection Deserialize(string contents);
    }

    /// <summary>
    /// Converts builders collection to and from text in JSON format.
    /// </summary>
    public class JsonConverter : IBuildersCollectionConverter
    {
        private sealed class FieldsContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                //Fields are used for builders; DTOs may and should use properties. this resolved the issue of 
                // inherited classes - should test this with some real-world applications with dto inheritance
                var kind = AnalyzeType(type);
                var jsonProperties = kind == Kind.Dto
                    ? type.GetProperties().Select(f => CreateProperty(f, memberSerialization)).ToList()
                    : type.GetRuntimeFields().Select(f => CreateProperty(f, memberSerialization)).ToList();

                foreach (var p in jsonProperties)
                {
                    p.Writable = true;
                    p.Readable = true;
                }

                return jsonProperties;
            }

            private static Kind AnalyzeType(Type type)
            {
                //using very naive approach - will add more elaborate
                //techniques later - analyzing public properties, fields, etc.
                const string dtoEnding = "DTO";
                const string builderEnding = "BUILDER";
                var name = type.Name;
                if (name.ToUpper().EndsWith(dtoEnding))
                {
                    return Kind.Dto;
                }
                if (name.ToUpper().EndsWith(builderEnding))
                {
                    return Kind.Builder;
                }
                return Kind.Other;
            }

            private enum Kind
            {
                Builder = 1,
                Dto = 2,
                Other = 3
            }
        }

        /// <inheritdoc />
        public string Serialize(BuildersCollection buildersCollection)
        {
            var serializerSettings = CreateSerializerSettings();
            return JsonConvert.SerializeObject(buildersCollection, serializerSettings);
        }

        /// <inheritdoc />
        public BuildersCollection Deserialize(string contents)
        {
            var serializerSettings = CreateSerializerSettings();
            return JsonConvert.DeserializeObject<BuildersCollection>(contents, serializerSettings);
        }

        private static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = new FieldsContractResolver()
            };
        }
    }
}