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
    [TestFixture]
    public class LuckyNumberTests
    {
        private Mock<INumberRepository> _mockNumberRepository;
        private Mock<IDateTimeProvider> _mockDateTimeProvider;
        private Mock<Action<string>> _mockLogAction;

        [SetUp]
        public void SetUp()
        {
            // Inicjalizacja mocków przed każdym testem
            _mockNumberRepository = new Mock<INumberRepository>();
            _mockDateTimeProvider = new Mock<IDateTimeProvider>();
            _mockLogAction = new Mock<Action<string>>();
        }

        [Test]
        public void Generate_ShouldReturnNumberWithinExpectedRange()
        {
            // Arrange
            var random = new Mock<Random>();
            random.Setup(r => r.Next(100)).Returns(42);  // Mockowanie, aby zwróciło zawsze 42

            var luckyNumber = new LuckyNumber(
                random: random.Object,
                numberRepository: _mockNumberRepository.Object,
                dateTimeProvider: _mockDateTimeProvider.Object,
                logAction: _mockLogAction.Object);

            // Act
            var result = luckyNumber.Generate();

            // Assert
            result.Should().BeInRange(0, 99);  // FluentAssertions
        }

        [Test]
        public void Generate_ShouldCallAddRandomNumberOnce()
        {
            // Arrange
            var luckyNum = 42;
            var currentDateTime = DateTime.Now;

            _mockDateTimeProvider.Setup(d => d.Now).Returns(currentDateTime);

            var random = new Mock<Random>();
            random.Setup(r => r.Next(100)).Returns(luckyNum);  // Mockowanie, aby zwróciło 42

            var luckyNumber = new LuckyNumber(
                random: random.Object,
                numberRepository: _mockNumberRepository.Object,
                dateTimeProvider: _mockDateTimeProvider.Object,
                logAction: _mockLogAction.Object);

            // Act
            luckyNumber.Generate();

            // Assert
            _mockNumberRepository.Verify(r => r.AddRandomNumber(luckyNum, currentDateTime), Times.Once);
        }

        [Test]
        public void Generate_ShouldLogLuckyNumber()
        {
            // Arrange
            var luckyNum = 42;

            // Mockowanie Random.Next, aby zwróciło 42
            var mockRandom = new Mock<Random>();
            mockRandom.Setup(r => r.Next(100)).Returns(luckyNum);

            var luckyNumber = new LuckyNumber(
                random: mockRandom.Object,
                numberRepository: _mockNumberRepository.Object,
                dateTimeProvider: _mockDateTimeProvider.Object,
                logAction: _mockLogAction.Object);

            // Act
            luckyNumber.Generate();

            // Assert
            _mockLogAction.Verify(log => log($"Szczęśliwa liczba to: {luckyNum}"), Times.Once);
        }
    }
}
