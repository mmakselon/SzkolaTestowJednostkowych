using FluentAssertions;
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
        public void Login_WhenCorrectData_ShouldReturnEmptyString()
        {
            var authentication = new Authentication(new FakeUserRepository());

            var result = authentication.Login("1", "2");

            result.Should().BeEmpty();
        }

        [Test]
        public void Login_WhenInCorrectData_ShouldReturnCorrectMessage()
        {
            var authentication = new Authentication(new FakeUserRepository());

            var result = authentication.Login("1", "3");

            result.Should().Contain("User or password is incorrect.");
        }
    }
}
