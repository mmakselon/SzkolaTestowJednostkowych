using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Mocking;

namespace SzkolaTestowJednostkowych_UnitTests.Mocking
{
    internal class ConfigHelperTests
    {
        private Mock<IFileReader> _mockFileReader;
        private ConfigHelper _configHelper;

        private void Init()
        {
            _mockFileReader = new Mock<IFileReader>();
            _configHelper = new ConfigHelper(_mockFileReader.Object);
        }

        [Test]
        public void GetConnectionString_WhenCalled_ShouldReturnConnectionString()
        {
            Init();

            var config = new Config { ConnectionString = "1" };
            var jsonConfig = JsonConvert.SerializeObject(config);
            _mockFileReader.Setup(x=>x.Read(It.IsAny<string>())).Returns(jsonConfig);
            
            var connectionString = _configHelper.GetConnectionString();

            connectionString.Should().Be(config.ConnectionString);
        }
        [Test]
        public void GetConnectionString_WhenConfigIsNull_ShouldThrowExceptionWithCorrectMessage()
        {
            Init();
            _mockFileReader.Setup(x => x.Read(It.IsAny<string>())).Returns("");

            Action action = () => _configHelper.GetConnectionString();

            action.Should().ThrowExactly<Exception>().WithMessage("*Incorrect parsing config*");
        }

    }
}
