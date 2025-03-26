using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Mocking;
using SzkolaTestowJednostkowych_UnitTests.Models;

namespace SzkolaTestowJednostkowych_UnitTests.Mocking
{
    class AuthenticationTest
    {
        [Test]
        public void Login_WhenCorrectData_ShouldReturnEmptyString_Imperatywna()
        {
            var mockUserRepository = new Mock<IUsersRepository>();
            mockUserRepository
                .Setup(x => x.Login("1", "2"))
                .Returns(true);

            var authentication = new Authentication(mockUserRepository.Object);

            var result = authentication.Login("1", "2");

            result.Should().BeEmpty();
        }

        [Test]
        public void Login_WhenCorrectData_ShouldReturnEmptyString_Deklaratywnaa()
        {
            var mockUserRepository = Mock.Of<IUsersRepository>(x=>x.Login("1","2") == true);

            var authentication = new Authentication(mockUserRepository);

            var result = authentication.Login("1", "2");

            result.Should().BeEmpty();
        }

        [Test]
        public void Login_WhenInCorrectData_ShouldReturnCorrectMessage()
        {
            var mockUserRepository = new Mock<IUsersRepository>();

            mockUserRepository
                .Setup(x => x.Login("1", "2"))
                .Returns(false);

            var authentication = new Authentication(mockUserRepository.Object);

            var result = authentication.Login("1", "2");

            result.Should().Contain("User or password is incorrect.");
        }
    }
}
