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


        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }


        [Test]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_TwoPositiveNumbers_ShouldReturnSum()
        {
            //Arrange - przygotowanie, inicjalizacja
            //var calculator = new Calculator();

            //Act - działanie
            var result = _calculator.Add(1, 2);

            //Assert - weryfikacja
            result.Should().Be(3);
        }

        [Test]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_TwoNegativeNumbers_ShouldReturnSum()
        {
            //Act - działanie
            var result = _calculator.Add(-1, -2);

            //Assert - weryfikacja
            result.Should().Be(-3);
        }

        [Test]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_OnePositiveAdnOneNegativeNumbers_ShouldReturnSum()
        {
            //Arrange - przygotowanie, inicjalizacja
            //var calculator = new Calculator();

            //Act - działanie
            var result = _calculator.Add(1, -2);

            //Assert - weryfikacja
            result.Should().Be(-1);
        }

        [Test]
        public void Subtraction_WhenCalled_ShouldReturnSubtraction()
        { 
            var result = _calculator.Subtraction(1, 2);

            result.Should().Be(-1);
        }
    }
}
