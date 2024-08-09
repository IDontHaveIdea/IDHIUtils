//
// Utilities Json
//

using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;


namespace IDHIUtils
{
    public partial class Utilities
    {
        public static T ReadJsonFile<T>(string strFile, string dir)
        {
            var result = default(T);

            var rootPath = Path.Combine(UserData.Path, dir);
            var rootDirectory = new DirectoryInfo(rootPath);
            var files = rootDirectory.GetFiles("*.json", SearchOption.AllDirectories);
            var fileName = strFile;
            string stem;

            foreach (var f in files)
            {
                stem = Path.GetFileNameWithoutExtension(f.Name);
                if (stem == fileName)
                {
                    using var file = File.OpenText(f.FullName);

                    var serializer = new JsonSerializer();
                    result = (T)serializer
                        .Deserialize(file, typeof(T));
                }
            }
            return result;
        }

        /// <summary>
        /// Read json file it looks for it rootPath and it subdirectories returns the first one
        /// found
        /// </summary>
        /// <typeparam name="T">Type of deserialize data read</typeparam>
        /// <param name="strFile">file name to read</param>
        /// <param name="rootPath">root directory to start search</param>
        /// <returns></returns>
        public static T ReadJson<T>(string strFile, string rootPath)
        {
            var result = default(T);

            var rootDirectory = new DirectoryInfo(rootPath);
            var files = rootDirectory.GetFiles("*.json", SearchOption.AllDirectories);
            var fileName = strFile;
            string stem;

            foreach (var f in files)
            {
                stem = Path.GetFileNameWithoutExtension(f.Name);
                if (stem == fileName)
                {
                    using var file = File.OpenText(f.FullName);

                    var serializer = new JsonSerializer();
                    result = (T)serializer
                        .Deserialize(file, typeof(T));
                }
            }
            return result;
        }
    }
}
