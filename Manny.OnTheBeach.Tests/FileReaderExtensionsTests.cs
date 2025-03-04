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
            // Arrange & Act
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
            // Arrange
            var results = new List<HotelData>();

            // Act
            var stream = FullFilePath.ReadFile();
            results = await stream.ConvertToListAsync<HotelData>();

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.EqualTo(13));
        }

        [Test]
        public async Task GetDataFromFileAsync_Combined_ReturnsExpectedData()
        {
            // Arrange & Act
            var results = await FullFilePath.GetDataFromFileAsync<HotelData>();

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.EqualTo(13));
        }
    }
}