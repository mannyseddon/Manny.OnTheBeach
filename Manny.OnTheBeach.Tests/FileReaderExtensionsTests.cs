using NUnit.Framework;

namespace Manny.OnTheBeach.Tests
{
    [TestFixture]
    public class FileReaderExtensionsTests
    {
        private const string TestFilePath = "hotels.json";

        [Test]
        public void ReadFile_ValidFilePath_ReturnsFileStream()
        {
            // Act & Assert
            using (var result = TestFilePath.ReadFile())
            {
                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<FileStream>());
            }
        }
    }
}
