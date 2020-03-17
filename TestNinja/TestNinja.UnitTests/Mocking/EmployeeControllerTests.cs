using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _storage;
        
        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IEmployeeStorage>();
        }
        
        [Test]
        [Category("EmployeeController")]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var controller = new EmployeeController(_storage.Object);

            controller.DeleteEmployee(1);

            _storage.Verify(s => s.DeleteEmployee(1));
        }   
    }
}
