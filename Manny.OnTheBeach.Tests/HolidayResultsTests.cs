using Manny.OnTheBeach.Models.Data;
using NUnit.Framework;

namespace Manny.OnTheBeach.Tests
{
    [TestFixture]
    public class HolidayResultsTests
    {
        [Test]
        public async Task SearchHolidaysAsync_Customer1_ReturnsExpectedResult()
        {
            // Arrange
            var requirements = new HolidayRequirements
            {
                DepartingFrom = "MAN",
                TravelingTo = "AGP",
                DepartureDate = new DateOnly(2023, 7, 1),
                Duration = 7
            };

            var results = new List<HolidaySearchResults>();

            //Act
            results = await requirements.SearchHolidaysAsync();
            var bestResult = results.First();

            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.Not.EqualTo(0));
            Assert.That(bestResult.Flight.Id, Is.EqualTo(2));
            Assert.That(bestResult.Hotel.Id, Is.EqualTo(9));
            Assert.That(results, Is.InstanceOf<List<HolidaySearchResults>>());

            /* Flight 2 and Hotel 9*/
        }
    }
}