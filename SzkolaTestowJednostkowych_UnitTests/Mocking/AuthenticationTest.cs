using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Mocking;

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
    }
}
