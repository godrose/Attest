using System.IO;
using Solid.Common;

namespace Attest.Testing.Core.FakeData.Shared
{
    /// <summary>
    /// Enables storing and loading data of the specified type.
    /// </summary>
    public interface IDataStorage<T>
    {
        /// <summary>
        /// Stores the specified data at the specified resource identifier.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="data">The data.</param>
        void Store(string id, T data);
        /// <summary>
        /// Loads the data using the specified resource identifier.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <returns></returns>
        T Load(string id);
    }

    /// <summary>
    /// Stores and loads data to and from the local file system.
    /// </summary>
    public class LocalFileSystemDataStorage : IDataStorage<string>
    {
        /// <inheritdoc />
        public void Store(string id, string data)
        {
            PlatformProvider.Current.WriteText(Path.Combine(Directory.GetCurrentDirectory(), id), data);
        }

        /// <inheritdoc />
        public string Load(string id)
        {
            return PlatformProvider.Current.ReadText(Path.Combine(Directory.GetCurrentDirectory(), id));
        }
    }
}