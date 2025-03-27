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
    internal class OrderServiceTests
    {
        [Test]
        public void CalculateDiscount_WhenCustomerIsNew_ShouldReturn0()
        {
            var orderService = new OrderService();

            var discount = orderService.CalculateDiscount(1m,new Customer { IsNewCustomer = true });

            discount.Should().Be(0);
        }
    }
}
