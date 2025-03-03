using System.Text.Json;

namespace Manny.OnTheBeach.FileReader
{
    public static class FileReaderExtensions
    {
        public static async Task<List<T>> GetDataFromFileAsync<T>(this string filePath)
        {
            var data = await filePath.ReadFile().ConvertToListAsync<T>();

            return data;
        }

        public static FileStream ReadFile(this string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return fileStream;
        }

        public static async Task<List<T>> ConvertToListAsync<T>(this FileStream stream)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var results = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(stream, options);

            return results?.ToList() ?? new List<T>();
        }

    }
}
