using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Solid.Practices.Composition;

namespace Attest.Testing.Core.FakeData.Shared
{
    /// <summary>
    /// Enables storing and loading builders collection.
    /// </summary>
    public interface IBuildersCollectionStorage
    {
        /// <summary>
        /// Stores the specified builders collection at the specified resource identifier.
        /// </summary>
        /// <param name="buildersCollection">The builders collection.</param>
        /// <param name="id">The resource identifier.</param>
        void Store(BuildersCollection buildersCollection, string id);

        /// <summary>
        /// Loads the builders collection using the specified resource identifier.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        BuildersCollection Load(string id);
    }    

    /// <summary>
    /// Enables storing and loading builders collection using JSON format.
    /// </summary>
    /// <seealso cref="IBuildersCollectionStorage" />
    public class JsonBuildersCollectionStorage : IBuildersCollectionStorage
    {
        /// <summary>
        /// Stores the specified builders collection.
        /// </summary>
        /// <param name="buildersCollection">The builders collection.</param>
        /// <param name="id">The identifier.</param>
        public void Store(BuildersCollection buildersCollection, string id)
        {
            var serializerSettings = CreateSerializerSettings();
            var str = JsonConvert.SerializeObject(buildersCollection, serializerSettings);
            PlatformProvider.Current.WriteText(Path.Combine(Directory.GetCurrentDirectory(), id), str);
        }

        /// <summary>
        /// Loads the builders collection using the specified resource identifier.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        public BuildersCollection Load(string id)
        {                        
            var str = PlatformProvider.Current.ReadText(Path.Combine(Directory.GetCurrentDirectory(), id));
            var serializerSettings = CreateSerializerSettings();
            return JsonConvert.DeserializeObject<BuildersCollection>(str, serializerSettings);
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

    internal sealed class FieldsContractResolver : DefaultContractResolver
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
}
