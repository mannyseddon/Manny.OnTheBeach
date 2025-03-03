using Manny.OnTheBeach.FileReader;
using Manny.OnTheBeach.Models.Data;
using NUnit.Framework;

namespace Manny.OnTheBeach.Tests
{
    [TestFixture]
    public class FileReaderExtensionsTests
    {
        private const string TestFilePath = "hotels.json";
        private static readonly string FullFilePath = Path.Combine(@"..\..\..\..\", TestFilePath);

        [Test]
        public void ReadFile_ValidFilePath_ReturnsFileStream()
        {
            // Act & Assert
            using (var result = FullFilePath.ReadFile())
            {
                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<FileStream>());
            }
        }

        [Test]
        public async Task GetDataFromFileAsync_ValidFile_ReturnsExpectedData()
        {
            // Act
            var result = new List<Hotel>();

            var stream = FullFilePath.ReadFile();
            result = await stream.ConvertToListAsync<Hotel>();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(13));
        }

        [Test]
        public async Task GetDataFromFileAsync_Combined_ReturnsExpectedData()
        {
            // Act
            var result = await FullFilePath.GetDataFromFileAsync<Hotel>();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(13));
        }
    }
}