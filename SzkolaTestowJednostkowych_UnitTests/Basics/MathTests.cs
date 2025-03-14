using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    class MathTests
    {
        [Test]
        public void GetNwd_WhenCalled_ShouldReturnNwd()
        {
            //arrange
            var math = new SzkolaTestowJednostkowych.Basics.Math();

            //act
            var result = math.GetNwd(3, 6);

            //assert
            result.Should().Be(3);
            //result.Should().BeGreaterThanOrEqualTo(3);
        }

        [Test]
        public void GetEvenNumbers_WhenCalled_ShouldReturnEvenNumbersInGivenRange()
        {
            var math = new SzkolaTestowJednostkowych.Basics.Math();

            var evenNumbers = math.GetEvenNumbers(4);

            //evenNumbers.Should().NotBeEmpty();
            //evenNumbers.Should().HaveCount(2);
            evenNumbers.Should().BeEquivalentTo(new[] { 2, 4 });

            //evenNumbers.Should().Contain(2);
            //evenNumbers.Should().Contain(new[] {2,4});
            //evenNumbers.Should().NotBeEquivalentTo(new[] { 1, 3 });
            //evenNumbers.Should().OnlyHaveUniqueItems();
        }

        [TestCase(2,"Even")]
        [TestCase(4, "Even")]
        [TestCase(1, "Odd")]
        [TestCase(1, "Odd")]
        public void GetEvenOrOddMsg_WhenCalled_ShouldReturnCorrectMsg(int number, string message)
        {
            var math = new SzkolaTestowJednostkowych.Basics.Math();

            var msg = math.GetEvenOrOddMsg(number);

            msg.Should().Be(message);
        }
    }
}
