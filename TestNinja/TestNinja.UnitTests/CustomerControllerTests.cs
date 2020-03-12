using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [Parallelizable]
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());

            //InstanceOf means that the result can be a Not Found object or any of its derivatives.
            Assert.That(result, Is.InstanceOf<NotFound>());
        }
    }
}
