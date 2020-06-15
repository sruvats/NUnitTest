using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        private Mock<IEmployeeStore> employeeStore;
        private EmployeeController empController;
        [SetUp]
        public void SetUp()
        {
            employeeStore = new Mock<IEmployeeStore>();
            empController = new EmployeeController(employeeStore.Object);
        }
        [Test]
        public void deleteEmployee_whenDeleted_returnTrue()
        {
        //    employeeStore.Setup(emp => emp.getEmployee(It.IsAny<int>())).Returns(true);
            //  var result= empController.DeleteEmployee(It.IsAny<int>());

            //   Assert.That(result, Is.True);

            empController.DeleteEmployee(1);
            employeeStore.Verify(s => s.getEmployee(1));
        }
    }
}
