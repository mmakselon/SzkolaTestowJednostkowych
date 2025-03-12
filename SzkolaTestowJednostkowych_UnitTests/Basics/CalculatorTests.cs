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


        private void Init()
        {
            _calculator = new Calculator();
        }


        [TestCase(1, 2, 3)]
        [TestCase(-1, -2, -3)]
        [TestCase(1, -2, -1)]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_WhenCalled_ShouldReturnSum(int number1, int number2, int expectedResult)
        {
            //Arrange - przygotowanie, inicjalizacja
            //var calculator = new Calculator();
            Init();

            //Act - działanie
            var result = _calculator.Add(number1, number2);

            //Assert - weryfikacja
            result.Should().Be(expectedResult);
        }      

        [Test]
        public void Subtraction_WhenCalled_ShouldReturnSubtraction()
        {
            Init();

            var result = _calculator.Subtraction(1, 2);

            result.Should().Be(-1);
        }
    }
}
