using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Basics;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    internal class MyQueueTests
    {
        private MyQueue<string> _queue;

        private void InitQueue()
        {
            _queue = new MyQueue<string>();
        }

        [Test]
        public void Equeue_WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            InitQueue();

            Action action = () => _queue.Enqueue(null);

            action.Should().ThrowExactly<ArgumentNullException>();
        }
        [Test]
        public void Equeue_WhenAddT_ShouldIncreaseCountFromList(Task value)
        {
            InitQueue();

            _queue.Enqueue("1");

            _queue.Count.Should().Be(1);
        }

        [Test]
        public void Peek_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            InitQueue();

            Action action = () => _queue.Peek();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Test]
        public void Peek_WhenQueueHasItems_ShouldReturnFirstItem()
        {
            InitQueue();
            _queue.Enqueue("1");
            _queue.Enqueue("2");
            _queue.Enqueue("3");

            var item = _queue.Peek();

            item.Should().Be("1");
        }

        [Test]
        public void Peek_WhenQueueHasItems_ShouldNotRemoveAnyItem()
        {
            InitQueue();

            _queue.Enqueue("1");
            _queue.Enqueue("2");
            _queue.Enqueue("3");

            _queue.Peek();

            _queue.Count.Should().Be(3);
        }

        [Test]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            InitQueue();

            Action action = () => _queue.Dequeue();

            action.Should().ThrowExactly<InvalidOperationException>();

        }

        [Test]
        public void Dequeue_WhenQueueHasItems_ShouldReturnFirstItem()
        {
            InitQueue();

            _queue.Enqueue("1");
            _queue.Enqueue("2");
            _queue.Enqueue("3");

            var item = _queue.Dequeue();

            item.Should().Be("1");
        }

        [Test]
        public void Dequeue_WhenQueueHasItems_ShouldRemoweFirstItem()
        {
            InitQueue();

            _queue.Enqueue("1");
            _queue.Enqueue("2");
            _queue.Enqueue("3");

            _queue.Dequeue();

            _queue.Count.Should().Be(2);
        }
    }
}
