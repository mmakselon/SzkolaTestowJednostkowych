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
        [Test]
        public void Method_Scenario_ExpectedBehaviour()
        {

        }
    }
}
