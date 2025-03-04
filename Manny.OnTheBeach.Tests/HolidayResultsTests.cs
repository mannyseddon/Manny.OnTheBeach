using Manny.OnTheBeach.Models;
using Manny.OnTheBeach.Search;
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
                DepartingFrom = new List<string> { "MAN" },
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
            Assert.That(bestResult.TotalPrice, Is.EqualTo(826));
            Assert.That(results, Is.InstanceOf<List<HolidaySearchResults>>());
        }

        [Test]
        public async Task SearchHolidaysAsync_Customer2_ReturnsExpectedResult()
        {
            // Arrange
            var requirements = new HolidayRequirements
            {
                DepartingFrom = new List<string> { "LTN", "LGW" },
                TravelingTo = "PMI",
                DepartureDate = new DateOnly(2023, 06, 15),
                Duration = 10
            };

            var results = new List<HolidaySearchResults>();

            //Act
            results = await requirements.SearchHolidaysAsync();
            var bestResult = results.First();

            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.Not.EqualTo(0));
            Assert.That(bestResult.Flight.Id, Is.EqualTo(6));
            Assert.That(bestResult.Hotel.Id, Is.EqualTo(5));
            Assert.That(bestResult.TotalPrice, Is.EqualTo(675));
            Assert.That(results, Is.InstanceOf<List<HolidaySearchResults>>());
        }

        [Test]
        public async Task SearchHolidaysAsync_Customer3_ReturnsExpectedResult()
        {
            // Arrange
            var requirements = new HolidayRequirements
            {
                DepartingFrom = new List<string>(),
                TravelingTo = "LPA",
                DepartureDate = new DateOnly(2022, 11, 10),
                Duration = 14
            };

            var results = new List<HolidaySearchResults>();

            //Act
            results = await requirements.SearchHolidaysAsync();
            var bestResult = results.First();
            
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.Not.EqualTo(0));
            Assert.That(bestResult.Flight.Id, Is.EqualTo(7));
            Assert.That(bestResult.Hotel.Id, Is.EqualTo(6));
            Assert.That(bestResult.TotalPrice, Is.EqualTo(1175));
            Assert.That(results, Is.InstanceOf<List<HolidaySearchResults>>());
        }
    }
}