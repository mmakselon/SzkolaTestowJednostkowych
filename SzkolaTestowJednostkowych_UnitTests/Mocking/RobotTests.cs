using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Mocking;

namespace SzkolaTestowJednostkowych_UnitTests.Mocking
{
    internal class RobotTests
    {
        [Test]
        public void Greetings_ReturnsDayGreeting_WhenBefore18()
        {
            // Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(c => c.GetCurrentHour()).Returns(10); // godzina przed 18:00

            var robot = new Robot(mockClock.Object);

            // Act
            var result = robot.Greetings();

            // Assert
            result.Should().Contain("Dzień dobry!");
        }

        [Test]
        public void Greetings_ReturnsEveningGreeting_WhenArter18()
        {
            // Arrange
            var mockClock = new Mock<IClock>();
            mockClock.Setup(c => c.GetCurrentHour()).Returns(19); // godzina po 18:00

            var robot = new Robot(mockClock.Object);

            // Act
            var result = robot.Greetings();

            // Assert
            result.Should().Contain("Dobry wieczór!");
        }

        //jedna ogólna metoda zamiast dwóch powyżej
        [TestCase("2025-01-01 17:59", "Dzień dobry")]
        [TestCase("2025-01-01 18:00", "Dobry wieczór")]
        [TestCase("2025-01-01 18:01", "Dobry wieczór")]
        public void Greetings_WhenCalled_ShouldReturnCorrectMessage(DateTime date, string expectedMessage)
        {
            var mockClock = new Mock<IClock>();
            mockClock.Setup(c => c.GetCurrentHour()).Returns(date.Hour);
            var robot = new Robot(mockClock.Object);

            // Act
            var result = robot.Greetings();

            result.Should().Contain(expectedMessage);
        }
    }
}
