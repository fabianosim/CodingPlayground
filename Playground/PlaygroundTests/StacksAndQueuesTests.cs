using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.CrackingTheCode;

namespace PlaygroundTests
{
    [TestFixture]
    public class StacksAndQueuesTests
    {
        [Test]
        public void OnMyQueueEnqueue_ShouldEnqueueItems()
        {
            // Arrange
            MyQueue<int> queue = new MyQueue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            // Assert
            Assert.That(5, Is.EqualTo(queue.Size()));
        }

        [Test]
        public void OnMyQueueEnqueueAndPop_ShouldDequeueItems_ShouldShowDequeuedItems()
        {
            // Arrange
            MyQueue<int> queue = new MyQueue<int>();

            // Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            int value1 = queue.Dequeue();
            int value2 = queue.Dequeue();

            queue.Enqueue(5);

            int value3 = queue.Dequeue();
            int value4 = queue.Dequeue();
            int value5 = queue.Dequeue();
            int value6 = queue.Dequeue();

            // Assert
            Assert.That(1, Is.EqualTo(value1));
            Assert.That(2, Is.EqualTo(value2));
            Assert.That(3, Is.EqualTo(value3));
            Assert.That(4, Is.EqualTo(value4));
            Assert.That(5, Is.EqualTo(value5));
            Assert.That(5, Is.EqualTo(value6));

        }
    }
}
