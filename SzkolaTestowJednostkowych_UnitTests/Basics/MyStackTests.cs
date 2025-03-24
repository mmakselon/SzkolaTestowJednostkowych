using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Basics;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    internal class MyStackTests
    {
        private MyStack<string> _myStack;

        private void InitMyStack()
        {
            _myStack = new MyStack<string>();
        }

        [Test]
        public void Push_WhenAddObject_ShouldAddObjectToList()
        {
            InitMyStack();

            _myStack.Push("1");

            _myStack.Count.Should().Be(1);
        }

        [Test]
        public void Push_WhenAddNullObject_ShouldThrowArgumentNullException()
        {
            InitMyStack();

            Action action = () => _myStack.Push(null);

            action.Should().ThrowExactly<ArgumentNullException>();

        }

        [Test]
        public void Pop_WhenListIsNull_ShouldThrowInvalidOperationException()
        {
            InitMyStack();

            Action action = () => _myStack.Pop();

            action.Should().ThrowExactly<InvalidOperationException>();

        }

        [Test]
        public void Pop_WhenListIsNotNull_ShouldReturnLastObjectAndRemoveIt()
        {
            InitMyStack();

            _myStack.Push("1");
            _myStack.Push("2");

            var item = _myStack.Pop();

            item.Should().Be("2");
            _myStack.Count.Should().Be(1);
        }

        [Test]
        public void Peek_WhenListIsNull_ShouldReturnInvalidOperationException()
        {
            InitMyStack();

            Action action = () => _myStack.Peek();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Test]
        public void Peek_WhenListIsNotNull_ShouldReturnLastObject()
        {
            InitMyStack();

            _myStack.Push("1");
            _myStack.Push("2");
            _myStack.Push("3");

            _myStack.Peek().Should().Be("3");
        }
    }
}
