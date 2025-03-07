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
        [Test]
        //NazwaMetody_Scenariusz_OczekiwanyRezultat
        public void Add_WhenCalled_ShouldReturnSum()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(1, 2);

            //Assert
            Assert.That(result,Is.EqualTo(3));
        }
    }
}
