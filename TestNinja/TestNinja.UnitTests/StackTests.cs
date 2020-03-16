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
        [Category("Stack")]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        [Category("Stack")]
        public void Push_ValidArg_AddTheObjectToStack()
        {
            var stack = new Fundamentals.Stack<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        [Category("Stack")]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }


        [Test]
        [Category("Stack")]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Stack")]
        public void Pop_StackWithFewObjects_ReturnsObjectOnTop()
        {
            //Arrange
            var stack = new Fundamentals.Stack<string>();
            stack.Push("a");
            stack.Push("b");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        [Category("Stack")]
        public void Pop_StackWithFewObjects_RemoveObjectFromTop()
        {
            var stack = new Fundamentals.Stack<string>();

            stack.Push("a");
            stack.Push("b");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        [Category("Stack")]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Fundamentals.Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        [Category("Stack")]
        public void Peek_StackWithObjects_ReturnsObjectOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("b"));
        }

        [Test]
        [Category("Stack")]
        public void Peek_StackWithObjects_DoesNotRemoveObjectOnTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");

            var result = stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }


    }
}
