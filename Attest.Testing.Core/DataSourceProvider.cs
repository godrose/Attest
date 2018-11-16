using System.IO;
using Newtonsoft.Json;
using Solid.Practices.Composition;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Allows extracting data source by key.
    /// </summary>
    /// <typeparam name="TDataSource"></typeparam>
    public interface IDataSourceProvider<TDataSource>
    {
        /// <summary>
        /// Gets the data source by the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TDataSource GetDataSource(string key);
    }    
    
    /// <summary>
    /// Implementation of <see cref="IDataSourceProvider{TDataSource}"/> for local file system.
    /// </summary>
    /// <typeparam name="TDataSource"></typeparam>
    public class FileSystemDataSourceProvider<TDataSource> : IDataSourceProvider<TDataSource>
    {
        /// <inheritdoc />
        public TDataSource GetDataSource(string key)
        {
            var extension = FileExtension.TrimStart('.');
            var contents = PlatformProvider.Current.ReadText(Path.Combine(PlatformProvider.Current.GetRootPath(),
                RelativePath,
                $"{key}.{extension}"));
            return JsonConvert.DeserializeObject<TDataSource>(contents);
        }

        /// <summary>
        /// Override to provide custom location for data files. The default is the current folder.
        /// </summary>
        public virtual string RelativePath => string.Empty;

        /// <summary>
        /// Override to provide custom extension for data files. The only supported data format is json.
        /// </summary>
        public virtual string FileExtension => "json";
    }
}
