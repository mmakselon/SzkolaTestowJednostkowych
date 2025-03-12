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
    class BasketTests
    {
        [Test]
        public void AddProduct_WhenCalled_ShouldUpdateTotalPrice()
        {
            //arrange
            var basket = new Basket();
            basket.TotalPrice = 0;

            //act
            basket.AddProduct(new Product { Price = 1 });

            //assert
            basket.TotalPrice.Should().Be(1);


        }
    }
}
