using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    class MathTest
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
        }
    }
}
