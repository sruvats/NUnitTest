using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;
        
        [SetUp]
        public void SetUp()

        {
            //Assign
             _fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase(3,"Fizz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(5,"Buzz")]
        [TestCase(1,"1")]
 public void GetOutput_whenCalled_ReturnString(int number,string expectedResult)
        {
            //Assert

            string result = FizzBuzz.GetOutput(number);

            //Act
            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }
}
