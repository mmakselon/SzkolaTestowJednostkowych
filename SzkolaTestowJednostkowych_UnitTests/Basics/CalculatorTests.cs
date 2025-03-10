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
    public class CalculatorTests
    {
        private Calculator _calculator;


        [OneTimeSetUp]
        public void SetOneTimeSetUpUp()
        {
            _calculator = new Calculator();
        }

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        { 
            _calculator = null; 
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _calculator = null;
        }


        [Test]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_WhenCalled_ShouldReturnSum()
        {
            //Arrange - przygotowanie, inicjalizacja
            //var calculator = new Calculator();

            //Act - działanie
            var result = _calculator.Add(1, 2);

            //Assert - weryfikacja
            result.Should().Be(3);
        }

        [Test]
        public void Subtraction_WhenCalled_ShouldReturnSubtraction()
        { 
            var result = _calculator.Subtraction(1, 2);

            result.Should().Be(-1);
        }
    }
}
