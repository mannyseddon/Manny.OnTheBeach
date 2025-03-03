namespace Manny.OnTheBeach.FileReader
{
    public static class FileReaderExtensions
    {

        public static FileStream ReadFile(this string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            return fileStream;
        }

    }
}
