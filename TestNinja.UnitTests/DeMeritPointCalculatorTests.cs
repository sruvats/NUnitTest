using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DeMeritPointCalculatorTests
    {
        private DemeritPointsCalculator _demeritPoint;


        [SetUp]
        public void SetUp()
        {
             _demeritPoint = new DemeritPointsCalculator();
        }

        [Test]
       
        [TestCase(65,0)]
     public void CalculateDemeritPoints_whenCalled_SpeedLessThanOrEqualToLimit(int speed, int points)
        {
         int result= _demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(points));

        }

        [Test]
        [TestCase(201, 27)]
        public void CalculateDemeritPoints_whenCalled_SpeedGreaterThanMinLimitLesserThanMax(int speed, int points)
        {
            int result = _demeritPoint.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(points));

        }
        [Test]
        [TestCase(-1)]
        [TestCase(305)]
        public void CalculateDemeritPoints_whsenCalled_ReturnException(int speed)
        {
          var  calc = new DemeritPointsCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CalculateDemeritPoints(speed));

          //  Assert.That(() => calc.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>);

        }
    }
}
