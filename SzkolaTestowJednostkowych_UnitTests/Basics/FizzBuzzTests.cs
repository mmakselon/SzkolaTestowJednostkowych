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
    public class FizzBuzzTests
    {
        [TestCase(15,"FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(1, "1")]
        public void GetOutput_WhenCalled_ShouldReturnCorrectMsg(int number, string message)
        {
            var msg = FizzBuzz.GetOutput(number);

            msg.Should().Be(message);           
        }
    }
}
