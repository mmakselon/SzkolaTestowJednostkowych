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
    class InvoiceTests
    {
        [Test]
        public void AddPosition_WhenPositionIsNull_ShouldThrowArgumentNullException()
        {
            var invoice = new Invoice();

            Action action = () => invoice.AddPosition(null);

            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*position*");
        }

        [Test]
        public void AddPosition_WhenPositionIsUnavailable_ShouldThrowException()
        {
            var invoice = new Invoice();

            Action action = () => invoice.AddPosition(new InvoicePosition { IsAvailable = false});

            action.Should().Throw<Exception>().WithMessage("*position unavailable*");
            //action.Should().NotThrow();
            //action.Should().NotThrow<Exception>();
        }
    }
}
