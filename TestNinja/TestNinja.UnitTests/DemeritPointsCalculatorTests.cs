﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DemeritPointsCalculator();
        }


        [Test]
        [Category("DemeritPointsCalculator")]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenSpeedLessThanSpeedLimit_ReturnsDemeritPoints(int speed, int expectedResult)
        {
            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [Category("DemeritPointsCalculator")]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedIsOutOfRange_ThrowsException(int speed)
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(-5),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
