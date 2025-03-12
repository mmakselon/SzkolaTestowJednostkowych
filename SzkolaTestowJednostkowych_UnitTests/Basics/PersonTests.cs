using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Basics;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    class PersonTests
    {
        [NUnit.Framework.Test]
        public void ToString_WhenValidProperties_ShouldReturnFullName()
        {
            var person = new Person { FirstName = "1", LastName = "2" };
            
            var fullName = person.ToString();

            fullName.Should().Contain("1 2");
            //fullName.Should().Be("1 2.");
            //fullName.Should().NotBeNull();
            //fullName.Should().BeNull();
            //fullName.Should().BeEmpty();
            //fullName.Should().NotBeEmpty();
            //fullName.Should().HaveLength(4);
            //fullName.Should().BeEquivalentTo("1 2.");
            //fullName.Should().NotContain("3");
            //fullName.Should().StartWith("1");
        }
    }
}
