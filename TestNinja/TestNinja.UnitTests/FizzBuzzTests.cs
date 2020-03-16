using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [Category("FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [Category("FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [Category("FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [Category("FizzBuzz")]
        public void GetOutput_WhenCalled_ReturnSameNumber()
        {
            var result = FizzBuzz.GetOutput(7);

            Assert.That(result, Is.EqualTo("7"));
        }
    }
}
