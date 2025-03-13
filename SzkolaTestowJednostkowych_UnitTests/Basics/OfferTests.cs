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
    class OfferTests
    {
        [Test]
        public void SetTitle_WhenArgumentIsValid_ShouldRaiseOfferChangedEvent()
        {
            var offer = new Offer();

            using (var monitoredSubject = offer.Monitor())
            {
                offer.SetTitle("1");
                monitoredSubject.Should().Raise("OfferChanged");
            }
        }

        [Test]
        public void SetTitle_WhenArgumentIsValid_ShouldChangedTitle()
        {
            var offer = new Offer();

            offer.SetTitle("1");

            offer.Title.Should().Be("1");
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SetTitle_WhenArgumentIsInvalid_ShouldThrowException(string title)
        { 
            var offer = new Offer();

            Action action = () => offer.SetTitle(title);

            action.Should().ThrowExactly<ArgumentNullException>().WithMessage("*title*");
        }
    }
}
