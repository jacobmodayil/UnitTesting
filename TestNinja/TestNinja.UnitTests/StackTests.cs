using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        [Category("")]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

    }
}
